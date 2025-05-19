using System;
using Xunit;
using Moq;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Models;


namespace UnitTestDemo.tests;

public class ToDoServiceTest
{

    //ONE ISSUE WITH TESTS IN THIS SCENARIO
    //we need to moq the actual database\

    private readonly Mock<ITodoRepository> _mockRepo;
    
    private readonly TodoService _service;

    public ToDoServiceTest 
    {

        _mockRepo = new Mock<ITodoRepository>();
        _service = new TodoService(_mockRepo.Object);
    }


    [Fact]
    public async Task AddTodoAsync_AddsItem()
    {

        TodoItem newItem = new() { Title = "Test Adding", IsCompleted = false};
        _mockRepo.Setup(x => x.AddAsync(It.IsAny<TodoItem>)).ReturnsAsync(newItem);

        var result = await _services.AddTodoAsync("Test Adding");


        Assert.Equal(newItem, result);
        Assert.Equal("Test Adding", result.Title);
        Assert.False(result.IsCompleted);
        Assert.NotNull(result);


    }

}
