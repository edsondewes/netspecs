using System;
using netspecs.EF.Tests.Fixtures;

namespace netspecs.EF.Tests
{
    public abstract class TestBase : IDisposable
    {
        public UserContext Context { get; set; }

        public TestBase()
        {
            this.Context = new UserContext();
        }

        public void Dispose()
        {
            this.Context.Dispose();
            this.Context = null;
        }
    }
}
