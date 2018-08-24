// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;
using System.Collections.Generic;

namespace WeeC
{
    internal abstract class Token
    {
        public int LineNumber { get; internal set; }
        public int CharPosition { get; internal set; }
    }

    internal class Keyword : Token
    {
        internal sealed class Auto : Keyword { }
        internal sealed class Break : Keyword { }
        internal sealed class Case : Keyword { }
        internal sealed class Char : Keyword { }
        internal sealed class Const : Keyword { }
        internal sealed class Continue : Keyword { }
        internal sealed class Default : Keyword { }
        internal sealed class Do : Keyword { }
        internal sealed class Double : Keyword { }
        internal sealed class Else : Keyword { }
        internal sealed class Enum : Keyword { }
        internal sealed class Extern : Keyword { }
        internal sealed class Float : Keyword { }
        internal sealed class For : Keyword { }
        internal sealed class Goto : Keyword { }
        internal sealed class If : Keyword { }
        internal sealed class Int : Keyword { }
        internal sealed class Long : Keyword { }
        internal sealed class Register : Keyword { }
        internal sealed class Return : Keyword { }
        internal sealed class Short : Keyword { }
        internal sealed class Signed : Keyword { }
        internal sealed class Sizeof : Keyword { }
        internal sealed class Static : Keyword { }
        internal sealed class Struct : Keyword { }
        internal sealed class Switch : Keyword { }
        internal sealed class Typedef : Keyword { }
        internal sealed class Union : Keyword { }
        internal sealed class Unsigned : Keyword { }
        internal sealed class Void : Keyword { }
        internal sealed class Volatile : Keyword { }
        internal sealed class While : Keyword { }
        internal readonly static Dictionary<string, Func<Keyword>> Table = new Dictionary<string, Func<Keyword>>
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

    internal class Identifier : Token
    {
        public string Value { get; internal set; }
    }

    internal class Constant : Token
    {
        public string Value { get; internal set; }
    }

    internal class StringLiteral : Token
    {
    }

    internal class Operator : Token
    {
    }

    internal class Punctuator : Token
    {
    }

    internal class EndOfLine : Token
    {
    }
}