/*******************************************************************************
 * You may amend and distribute as you like, but don't remove this header!
 *
 * Required Notice: Copyright (C) EPPlus Software AB. 
 * https://epplussoftware.com
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.

 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
 * See the GNU Lesser General Public License for more details.
 *
 * The GNU Lesser General Public License can be viewed at http://www.opensource.org/licenses/lgpl-license.php
 * If you unfamiliar with this license or have questions about it, here is an http://www.gnu.org/licenses/gpl-faq.html
 *
 * All code and executables are provided "" as is "" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 *
 * Code change notes:
 * 
  Date               Author                       Change
 *******************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *******************************************************************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class TokenHandlerTests
    {
        private TokenizerContext _tokenizerContext;
        private TokenHandler _handler;

        [TestInitialize]
        public void Init()
        {
            var parsingContext = ParsingContext.Create();
            var tokenFactory = new TokenFactory(parsingContext.Configuration.FunctionRepository, null);
            _tokenizerContext = new TokenizerContext("test", null, tokenFactory);
            _handler = _tokenizerContext.CreateHandler();
        }


        [TestMethod]
        public void HasMoreTokensShouldBeTrueWhenTokensExists()
        {
            Assert.IsTrue(_handler.HasMore());
        }

        [TestMethod]
        public void HasMoreTokensShouldBeFalseWhenAllAreHandled()
        {
            for (var x = 0; x < "test".Length; x++ )
            {
                _handler.Next();
            }
            Assert.IsFalse(_handler.HasMore());
        }
    }
}