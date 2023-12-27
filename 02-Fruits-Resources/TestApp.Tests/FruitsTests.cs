using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "banana", 15 },
            { "apple", 10 },
            { "orange", 5 }
            // ["lemon"] = 10
        };

        string fruitName = "apple";
        int expected = 10;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "banana", 15 },
            { "apple", 10 },
            { "orange", 5 }
        };

        string fruitName = "strawberry";
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>();

        string fruitName = "apple";
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = null;

        string fruitName = "apple";
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "banana", 15 },
            { "apple", 10 },
            { "orange", 5 }
        };

        string fruitName = null;
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
