using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

    [Fact]
    public void Test_ClientsTableEmptyAtFirst()
    {
      //Arrange Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_EqualOverrideTrueIfClientNameIsSame()
    {
      Client firstClient = new Client("Joe");
      Client secondClient = new Client("Joe");

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_Save_SaveToDatabase()
    {
      //Arrange
      Client testClient = new Client("Joe");
      //Act
      testClient.Save();
      List<Client> expected = new List<Client>{testClient};
      List<Client> actual = Client.GetAll();
      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Save_AssignedIdToClient()
    {
      Client testClient = new Client("Joe");
      testClient.Save();
      int actual = Client.GetAll()[0].GetId();
      int expected = testClient.GetId();

      Assert.Equal(expected, actual);
    }
  }
}
