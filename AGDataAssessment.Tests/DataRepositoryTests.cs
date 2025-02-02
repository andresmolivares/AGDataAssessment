using AGDataAssessment.Server.Persistence;
using FluentAssertions;
using NUnit.Framework;

namespace AGDataAssessment.Tests;

public class DataRepositoryTests: BaseTest
{
    [TestCase(_mockName, _mockAddress)]
    public void when_data_model_saved_with_name_address(string name, string address)
    {
        var mockRepo = new DataRepository();
        mockRepo.SaveData(name, address);

        var mockModel = mockRepo.GetData();

        mockModel.Should().NotBeNull();
        mockModel.Name.Should().Be(name);
        mockModel.Address.Should().Be(address);
    }

    [TestCase(_mockName, _emptyAddress)]
    public void when_data_model_saved_with_name_no_address(string name, string address)
    {
        var mockRepo = new DataRepository();
        mockRepo.SaveData(name, null);

        var mockModel = mockRepo.GetData();

        mockModel.Should().NotBeNull();
        mockModel.Name.Should().Be(name);
        mockModel.Address.Should().Be(address);
    }
}
