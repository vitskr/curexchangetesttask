using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Repository;
using Exchange.Types;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exchange.Tests
{
    public class InMemoryRepositoryTests
    {
        [Fact]
        public void InMemoryRepository_Reader_IsLazy()
        {
            var readerMock = new Mock<IRepositoryReader>();
            var inMemRepo = new InMemoryCurrencyRepository(readerMock.Object);

            readerMock.Verify(m => m.GetCurrencies(), Times.Never);
        }

        [Fact]
        public void InMemoryRepostitory_GetCurrency_ShoulReturnCurrency()
        {
            var expected = new Currency { ISO = "EUR", Name = "Euro", Rate = 7.4394m };

            var readerMock = new Mock<IRepositoryReader>();
            readerMock.Setup(m => m.GetCurrencies()).Returns(new[] { expected });

            var inMemRepo = new InMemoryCurrencyRepository(readerMock.Object);

            var actual = inMemRepo.GetCurrency("EUR");

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InMemoryRepostitory_UnknownCurrency_ShouldThrowKeyNotFound()
        {
            var readerMock = new Mock<IRepositoryReader>();
            var inMemRepo = new InMemoryCurrencyRepository(readerMock.Object);

            Action action = () => inMemRepo.GetCurrency("EUR");
            action
                .Should()
                .Throw<KeyNotFoundException>();
        }
    }
}
