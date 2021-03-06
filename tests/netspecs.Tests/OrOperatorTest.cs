﻿using System.Linq;
using netspecs.Tests.Fixtures;
using Xunit;

namespace netspecs.Tests
{
    public class OrOperatorTest
    {
        [Fact]
        public void ShouldMergeExpressions()
        {
            var spec1 = new GenericSpecification<User>(user => user.FavoriteNumber == 2);
            var spec2 = new GenericSpecification<User>(user => user.FavoriteNumber == 3);

            var x = new UserRepository().Where(spec1).ToList();
            var result = new UserRepository().Where(spec1 | spec2).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Maria Lucia", user.Name),
                user => Assert.Equal("Johny Pericles", user.Name));
        }

        [Fact]
        public void ShouldAcceptMultipleExpressions()
        {
            var spec1 = new GenericSpecification<User>(user => user.Name == "Maria Lucia");
            var spec2 = new GenericSpecification<User>(user => user.Name == "John Lister");
            var spec3 = new GenericSpecification<User>(user => user.Name == "Johny Pericles");

            var result = new UserRepository().Where(spec1 | spec2 | spec3).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Maria Lucia", user.Name),
                user => Assert.Equal("John Lister", user.Name),
                user => Assert.Equal("Johny Pericles", user.Name));
        }
    }
}
