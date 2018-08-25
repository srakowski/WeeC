// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Collections.Generic;

namespace WeeC
{
    internal static class Parser
    {
        public static TranslationUnit Parse(IEnumerable<Token> tokens)
        {
            return new TranslationUnit();
        }
    }
}
