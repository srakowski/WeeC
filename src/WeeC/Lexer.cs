// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Collections.Generic;

namespace WeeC
{
    internal class Lexer
    {
        internal static IEnumerable<Token> Analyze(string code)
        {
            var length = code.Length;
            var position = 0;
            var lineNumber = 0;
            var charPosition = 0;
            while (true)
            {
                while (position < length && char.IsWhiteSpace(code[position]))
                {
                    if (code[position] == '\n')
                    {
                        yield return Token<EndOfLine>(lineNumber, charPosition);
                        lineNumber++;
                        charPosition = 0;
                    }
                    else
                    {
                        charPosition++;
                    }
                    position++;
                }

                if (position == length)
                    break;

                char c = code[position];

                var tokenLineNumber = lineNumber;
                var tokenCharPosition = charPosition;

                if (IsStartOfIdentifier(c))
                {
                    var word = "";
                    while (IsIdentifierCharacter(c))
                    {
                        word += c;
                        charPosition++;
                        position++;
                        c = code[position];
                    }
                    
                    if (Keyword.Table.ContainsKey(word))
                    {
                        var keywordToken = Keyword.Table[word]();
                        keywordToken.LineNumber = lineNumber;
                        keywordToken.CharPosition = tokenCharPosition;
                        yield return keywordToken;
                        continue;
                    }

                    var identifier = Token<Identifier>(tokenLineNumber, tokenCharPosition);
                    identifier.Value = word;
                    yield return identifier;
                    continue;
                }

                if (char.IsDigit(c))
                {
                    // just integers for now...
                    var integer = "";
                    while (char.IsDigit(c))
                    {
                        integer += c;
                        charPosition++;
                        position++;
                        c = code[position];
                    }

                    var constant = Token<Constant.IntegerConstant>(tokenLineNumber, tokenCharPosition);
                    constant.Value = integer;
                    yield return constant;
                    continue;
                }

                if (c == '\'')
                {
                    continue;
                }

                if (c == '"')
                {
                    continue;
                }

                var nextPosition = position + 1;
                var nextC = nextPosition < length ? code[nextPosition] : '\0';
                switch (c)
                {
                    case '(': Token<Punctuator.LeftParen>(tokenLineNumber, tokenCharPosition); break;
                    case ')': break;
                    case '=': break;
                    case '+': break;
                    case '-': break;
                    case '*': break;
                    case '/': break;
                    case '%': break;
                    case '<': break;
                    case '>': break;
                    case ';': break;
                    case '&': break;
                    case '|': break;
                    case '{': break;
                    case '}': break;
                    case '[': break;
                    case ']': break;
                    case '!': break;
                    case '^': break;
                    case '~': break;
                    case ',': break;
                    case '.': break;
                    case '?': break;
                    case ':': break;
                    default: break;                                                                                                                                                              
                }
            }
        }

        private static T Token<T>(int lineNumber, int characterPosition) where T : Token, new()
        {
            var token = new T();
            token.LineNumber = lineNumber;
            token.CharPosition = characterPosition;
            return token;
        }

        private static bool IsStartOfIdentifier(char c) =>
            c == '_' || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        private static bool IsIdentifierCharacter(char c) =>
            IsStartOfIdentifier(c) || char.IsDigit(c);
    }
}