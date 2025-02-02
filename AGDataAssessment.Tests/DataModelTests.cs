using AGData.Services.Models;
using Bogus;
using FluentAssertions;
using NUnit.Framework;

namespace AGDataAssessment.Tests;

public class BaseTest
{
    protected const string _mockName = "John Doe";
    protected const string _mockAddress = "123 Main St";
    protected const string _emptyAddress = "Empty";
}

public class DataModelTests : BaseTest
{
    

    [TestCase(_mockName, _mockAddress)]
    public void when_data_model_is_valid(string name, string address)
    {
        var mockModel = new DataModel(name, address);

        mockModel.Should().NotBeNull();
        mockModel.Name.Should().NotBeNull();
        mockModel.Address.Should().NotBeNull();
    }

    [TestCase(_mockName, null)]
    public void when_data_model_is_valid_with_no_address(string name, string address)
    {
        var mockModel = new DataModel(name, address);

        mockModel.Should().NotBeNull();
        mockModel.Name.Should().NotBeNull();
        mockModel.Address.Should().BeNull();
    }

    [Test]
    public void when_data_model_is_invalid()
    {
        var ex = Assert.Catch(() => new Faker<DataModel>()
            .CustomInstantiator(f => new DataModel(string.Empty, f.Address.FullAddress()))
            .Generate(), 
            "Model invalid when initilized with no name");
        ex.Should().NotBeNull();
    }
}
