// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static WeeC.Token;

namespace WeeC
{
    internal static class Lexer
    {
        private struct CodeCharacter
        {
            public CodeCharacter(char value, int lineNumber, int linePosition)
            {
                Value = value;
                LineNumber = lineNumber;
                LinePosition = linePosition;
            }

            public char Value { get; }

            public int LineNumber { get; }

            public int LinePosition { get; }

            public bool IsWhitespace => char.IsWhiteSpace(Value);

            public bool IsDigit => Value >= '0' && Value <= '9';

            public bool IsStartOfIdentifier => Value == '_' || (Value >= 'a' && Value <= 'z') || (Value >= 'A' && Value <= 'Z');

            public bool IsBodyOfIdentifier => IsStartOfIdentifier || IsDigit;

            public bool IsStartOfCharacterConstant => Value == '\'';

            public bool IsStartOfStringLiteral => Value == '\"';
        }

        public static IEnumerable<Token> Analyze(string code) =>
            CodeCharacters(code)
                .Tokenize();

        private static IEnumerable<CodeCharacter> CodeCharacters(string code) =>
            code
                .Split('\n')
                .SelectMany((line, lineIndex) =>
                    line
                        .ToCharArray()
                        .Select((character, linePositionIndex) =>
                            new CodeCharacter(character, lineIndex + 1, linePositionIndex + 1)
                        )
                );

        private static IEnumerable<Token> Tokenize(this IEnumerable<CodeCharacter> code)
        {
            var nextToken = ReadToken(code);
            while (!(nextToken.Value is EndOfFile || nextToken.Value is InvalidToken))
            {
                Debug.WriteLine($"{nextToken.Value.TypeName} ({nextToken.Value.LineNumber},{nextToken.Value.LinePosition}) {nextToken.Value.Value}");
                yield return nextToken.Value;
                nextToken = nextToken.Next();
            }
            Debug.WriteLine($"{nextToken.Value.TypeName} ({nextToken.Value.LineNumber},{nextToken.Value.LinePosition}) {nextToken.Value.Value}");
            yield return nextToken.Value;
        }

        private struct NextToken
        {
            public NextToken(Token token, Func<NextToken> next)
            {
                Value = token;
                Next = next;
            }
            public Token Value { get; }
            public Func<NextToken> Next { get; }
        }
        
        private static NextToken ReadToken(this IEnumerable<CodeCharacter> code)
        {
            code = code.SkipWhile(c => c.IsWhitespace);

            if (!code.Any())
            {
                var token = new EndOfFile();
                return new NextToken(token, () => ReadToken(code));
            }

            var firstTokenChar = code.First();

            if (firstTokenChar.IsStartOfIdentifier)
            {
                var identifier = code
                    .TakeWhile(c => c.IsBodyOfIdentifier)
                    .Aggregate("", (s, c) => s + c.Value);

                code = code.SkipWhile(c => c.IsBodyOfIdentifier);

                var token = KeywordTable.ContainsKey(identifier)
                    ? KeywordTable[identifier].Invoke() as Token
                    : new Identifier();

                token.Value = identifier;
                token.LineNumber = firstTokenChar.LineNumber;
                token.LinePosition = firstTokenChar.LinePosition;
                return new NextToken(token, () => ReadToken(code));
            }

            if (firstTokenChar.IsDigit)
            {
                var number = code
                    .TakeWhile(c => c.IsDigit)
                    .Aggregate("", (s, c) => s + c.Value);

                code = code.Skip(number.Length);

                var token = new IntegerConstant();
                token.Value = number;
                token.LineNumber = firstTokenChar.LineNumber;
                token.LinePosition = firstTokenChar.LinePosition;
                return new NextToken(token, () => ReadToken(code));
            }

            if (firstTokenChar.IsStartOfStringLiteral)
            {
                var stringLiteral = code
                    .Skip(1)
                    .TakeWhile(c => c.Value != '"')
                    .Aggregate("\"", (s, c) => s + c.Value)
                    + '"';

                Debug.WriteLine(stringLiteral);

                code = code.Skip(stringLiteral.Length);

                var token = new StringLiteral();
                token.Value = stringLiteral;
                token.LineNumber = firstTokenChar.LineNumber;
                token.LinePosition = firstTokenChar.LinePosition;
                return new NextToken(token, () => ReadToken(code));
            }

            var t = new InvalidToken() as Token;

            switch (firstTokenChar.Value)
            {
                case '(': t = new LeftParen(); break;
                case ')': t = new RightParen(); break;
                case '{': t = new LeftCurlyBrace(); break;
                case '}': t = new RightCurlyBrace(); break;
                case '[': t = new LeftSquareBracket(); break;
                case ']': t = new RightSquareBracket(); break;
                case ',': t = new Comma(); break;
                case '*': t = new Asterisk(); break;
                case ';': t = new Semicolon(); break;
            }

            code = code.Skip(1);

            t.Value = firstTokenChar.Value.ToString();
            t.LineNumber = firstTokenChar.LineNumber;
            t.LinePosition = firstTokenChar.LinePosition;
            return new NextToken(t, () => ReadToken(code));
        }
    }
}