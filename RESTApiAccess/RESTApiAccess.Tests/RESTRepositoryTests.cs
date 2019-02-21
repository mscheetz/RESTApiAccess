// -----------------------------------------------------------------------------
// <copyright file="RESTRepositoryTests" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/20/2019 4:24:35 PM" />
// -----------------------------------------------------------------------------

namespace RESTApiAccess.Tests
{
    #region Usings

    using RESTApiAccess.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    
    #endregion Usings

    public class RESTRepositoryTests : IDisposable
    {
        #region Properties

        private IRESTRepository repo;

        #endregion Properties

        public RESTRepositoryTests()
        {
            repo = new RESTRepository();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Get_I_Test()
        {
        }
    }
}