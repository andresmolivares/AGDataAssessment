using AGData.Services.Dto;
using AGData.Services.Services;
using AGDataAssessment.Server.Persistence;
using FluentAssertions;
using NUnit.Framework;

namespace AGDataAssessment.Tests;

public class DataServiceTests : BaseTest
{
    [TestCase(_mockName, _mockAddress)]
    public void when_data_model_saved_with_name_address(string name, string address)
    {
        var mockRepo = new DataRepository();
        var mockService = new DataService(mockRepo);

        var dataModel = mockService.SaveData(new AddDataModelDto
        {
            Name = name,
            Address = address
        });

        dataModel.Should().NotBeNull();
        dataModel.Name.Should().Be(name);
        dataModel.Address.Should().Be(address);
    }

    [TestCase(_mockName, _emptyAddress)]
    public void when_data_model_saved_with_name_no_address(string name, string address)
    {
        var mockRepo = new DataRepository();
        var mockService = new DataService(mockRepo);
        mockRepo.SaveData(name, null);

        var dataModel = mockService.SaveData(new AddDataModelDto
        {
            Name = name,
            Address = address
        });

        dataModel.Should().NotBeNull();
        dataModel.Name.Should().Be(name);
        dataModel.Address.Should().Be(address);
    }
}