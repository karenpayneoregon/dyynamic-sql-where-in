using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Base;

namespace UnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Determine if company names are returned for WHERE IN condition
        /// </summary>
        [TestMethod]
        public void StringWhereConditions()
        {
            // arrange
            var expectedResults = new List<string>()
            {
                "Apple",
                "FaceBook",
                "Karen's Coffee"
            };

            // act
            var (list, _ ) = DataOperations.GetCustomersNamesBack(new List<string>()
            {
                "Apple",
                "FaceBook",
                "Karen's Coffee"
            });

            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));
        }

        [TestMethod]
        public void StringWhereInConditionsReturnKeys()
        {
            // arrange
            var expectedResults = new List<int>() { 2, 4, 5 };

            // act
            var (list, _ ) = DataOperations.GetCustomersKeysBack(new List<string>()
            {
                "Apple",
                "FaceBook",
                "Karen's Coffee"
            });
            
            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));
        }

        [TestMethod]
        public void StringWhereInConditionsReturnKeys_Access()
        {
            // arrange
            var expectedResults = new List<string>() 
                { 
                    "Ana Trujillo Emparedados y helados",
                    "Antonio Moreno Taquería",
                    "Bólido Comidas preparadas",
                    "Bon app'",
                    "Cactus Comidas para llevar",
                    "Chop-suey Chinese",
                    "Du monde entier",
                    "Eastern Connection",
                    "Familia Arquibaldo",
                    "Folk och fä HB",
                    "GROSELLA-Restaurante",
                    "Laughing Bacchus Wine Cellars",
                    "Let's Stop N Shop",
                    "LINO-Delicateses",
                    "Maison Dewey",
                    "Mère Paillarde",
                    "Morgenstern Gesundkost",
                    "Océano Atlántico Ltda.",
                    "Ottilies Käseladen",
                    "Paris spécialités",
                    "Queen Cozinha",
                    "Santé Gourmet",
                    "Simons bistro",
                    "The Cracker Box",
                    "Tortuga Restaurante",
                    "Victuailles en stock",
                    "White Clover Markets",
                    "Wolski  Zajazd"
                };

            // act
            var (list, _ ) = DataOperations.GetCustomersNamesBackFromAccess(new List<string>()
            {
                "Marketing Assistant",
                "Owner",
                "Sales Agent"
            });

            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));

        }

        /// <summary>
        /// Determine if company identifiers are returned for WHERE IN condition,
        /// validate by names of companies in expectedResults
        /// </summary>
        [TestMethod]
        public void IntWhereConditions()
        {
            // arrange
            var expectedResults = new List<string>()
            {
                "Apple",
                "FaceBook",
                "Karen's Coffee"
            };

            // act
            var (list, _ ) = DataOperations.GetByPrimaryKeys(new List<int>() { 2, 4, 5 });

            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));
        }

        /// <summary>
        /// Example for NOT IN condition, reverse of above method
        /// </summary>
        [TestMethod]
        public void IntWhereNotInConditions()
        {
            // arrange
            var expectedResults = new List<string>()
            {
                "Microsoft",
                "IBM",
                "Macy's",
                "JetBrains",
                "Telerik",
                "GemBox Software",
                "Red Gate"
            };

            // act
            var (list, _ ) = DataOperations.GetByPrimaryKeys_NotIn(new List<int>() { 2, 4, 5 });

            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));
        }
        /// <summary>
        /// Determine if specific dates are found in a table where in this case 
        /// these dates do exists.
        /// </summary>
        [TestMethod]
        public void DateWhereInConditions()
        {
            // arrange
            var expectedResults = new List<int>() { 1, 3 };

            // act
            var (list, _ ) = DataOperations.GetStartDatesList(new List<string>()
            {
                "2018-01-01", 
                "2017-01-03"
            });

            // assert
            Assert.IsTrue(expectedResults.SequenceEqual(list));
        }

        [TestMethod]
        public void UpdateExample()
        {
            var identifiers = new List<int>() { 1, 3,20, 2,  45 };
            var (actual, exposed) = DataOperations.UpdateExample(
                "UPDATE table SET column = 0 WHERE id IN", identifiers);

            Console.WriteLine(actual);
            Console.WriteLine(exposed);
        }


    }
}
