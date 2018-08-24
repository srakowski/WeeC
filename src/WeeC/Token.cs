// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;
using System.Collections.Generic;

namespace WeeC
{
    internal class Token
    {
        public class None : Token { }
        public class Comma : Token { }
        public class Assign : Token { }
        public class AddAssign : Token { }
        public class SubAssign : Token { }
        public class MulAssign : Token { }
        public class DivAssign : Token { }
        public class ModAssign : Token { }
        public class ShiftLeftAssign : Token { }
        public class ShiftRightAssign : Token { }
        public class BitwiseOrAssign : Token { }
        public class BitwiseXorAssign : Token { }
        public class BitwiseAndAssign : Token { }
        public class QuestionMark : Token { }
        public class Colon : Token { }
        public class Or : Token { }
        public class And : Token { }
        public class BitwiseOr : Token { }
        public class BitwiseXor : Token { }
        public class BitwiseAnd : Token { }
        public class Ampersand : Token { }
        public class Equal : Token { }
        public class NotEqual : Token { }
        public class LessThan : Token { }
        public class LessThanOrEqualTo : Token { }
        public class GreaterThan : Token { }
        public class GreaterThanOrEqualTo : Token { }
        public class ShiftLeft : Token { }
        public class ShiftRight : Token { }
        public class Plus : Token { }
        public class Minus : Token { }
        public class Asterisk : Token { }
        public class Slash : Token { }
        public class Modulus : Token { }
        public class Increment : Token { }
        public class Decrement : Token { }
        public class Not : Token { }
        public class BitwiseNot : Token { }
        public class Dot : Token { }
        public class Arrow : Token { }

        public abstract class ValueToken : Token
        { 
            public string Value { get; set; }
        }

        public class Identifier : ValueToken { }
        public class IntegerConstant : ValueToken { }
        public class FloatingPointConstant : ValueToken { }
        public class CharacterConstant : ValueToken { }
        public class StringLiteral : ValueToken { }

        public class Semicolon : Token { }
        public class Ellipsis : Token { }

        public class LeftSquareBracket : Token { }
        public class RightSquareBracket : Token { }
        public class LeftCurlyBrace : Token { }
        public class RightCurlyBrace : Token { }
        public class LeftParen : Token { }
        public class RightParen : Token { }

        public class Auto : Token { }
        public class Break : Token { }
        public class Case : Token { }
        public class Char : Token { }
        public class Const : Token { }
        public class Continue : Token { }
        public class Default : Token { }
        public class Do : Token { }
        public class Double : Token { }
        public class Else : Token { }
        public class Enum : Token { }
        public class Extern : Token { }
        public class Float : Token { }
        public class For : Token { }
        public class Goto : Token { }
        public class If : Token { }
        public class Int : Token { }
        public class Long : Token { }
        public class Register : Token { }
        public class Return : Token { }
        public class Short : Token { }
        public class Signed : Token { }
        public class Sizeof : Token { }
        public class Static : Token { }
        public class Struct : Token { }
        public class Switch : Token { }
        public class Typedef : Token { }
        public class Union : Token { }
        public class Unsigned : Token { }
        public class Void : Token { }
        public class Volatile : Token { }
        public class While : Token { }

        public class EndOfLine : Token { }
        public class EndOfFile : Token { }

        public class InvalidToken : Token { }

        public int LineNumber { get; set; }
        public int CharPosition { get; set; }

        public readonly static Dictionary<string, Func<Token>> KeywordTable = new Dictionary<string, Func<Token>>
        {
            {"auto", () => new Auto()},
            {"break", () => new Break()},
            {"case", () => new Case ()},
            {"char", () => new Char ()},
            {"const", () => new Const ()},
            {"continue", () => new Continue ()},
            {"default", () => new Default ()},
            {"do", () => new Do ()},
            {"double", () => new Double ()},
            {"else", () => new Else ()},
            {"enum", () => new Enum ()},
            {"extern", () => new Extern ()},
            {"float", () => new Float ()},
            {"for", () => new For ()},
            {"goto", () => new Goto ()},
            {"if", () => new If ()},
            {"int", () => new Int ()},
            {"long", () => new Long ()},
            {"register", () => new Register ()},
            {"return", () => new Return ()},
            {"short", () => new Short ()},
            {"signed", () => new Signed ()},
            {"sizeof", () => new Sizeof ()},
            {"static", () => new Static ()},
            {"struct", () => new Struct ()},
            {"switch", () => new Switch ()},
            {"typedef", () => new Typedef ()},
            {"union", () => new Union ()},
            {"unsigned", () => new Unsigned ()},
            {"void", () => new Void ()},
            {"volatile", () => new Volatile ()},
            {"while", () => new While ()}
        };
    }
}