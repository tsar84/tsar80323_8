using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using tsar80323.Controllers;
using tsar80323.DAL.Entities;
using tsar80323.Models;
using Xunit;



namespace tsar80323.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [
      Theory]
        [MemberData(memberName: nameof(TestData.Params),
      MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty,
      int id)
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int
        id)
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].DishId);
        }
    }
}
