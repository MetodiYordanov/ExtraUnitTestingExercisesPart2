using System;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string inputTitle = "someTitle";
        DateTime dateTime = DateTime.Now;
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[ ] {inputTitle} - Due: {dateTime.ToString("MM/dd/yyyy")}";

        // Act
        this._toDoList.AddTask(inputTitle, dateTime);
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string inputTitle = "someTitle";
        DateTime dateTime = DateTime.Now;
        this._toDoList.AddTask(inputTitle, dateTime);
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[✓] {inputTitle} - Due: {dateTime.ToString("MM/dd/yyyy")}";

        // Act
        this._toDoList.CompleteTask(inputTitle);
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string inputTitle = "someTitle";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => this._toDoList.CompleteTask(inputTitle));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        string expected = "To-Do List:";

        // Act
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string inputTitle = "someTitle";
        DateTime dateTime = DateTime.Now;
        string inputTitle2 = "someTitle";
        DateTime dateTime2 = new DateTime(2023, 11, 17);
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[ ] {inputTitle} - Due: {dateTime.ToString("MM/dd/yyyy")}" +
            $"{Environment.NewLine}[ ] {inputTitle2} - Due: {dateTime2.ToString("MM/dd/yyyy")}";

        // Act
        this._toDoList.AddTask(inputTitle, dateTime);
        this._toDoList.AddTask(inputTitle2, dateTime2);
        string result = this._toDoList.DisplayTasks();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
        //Assert.That(result, Does.Contain("[ ] someTitle - Due:"))
    }
}
