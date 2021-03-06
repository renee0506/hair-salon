using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
      Client firstClient = new Client("Joe", 1);
      Client secondClient = new Client("Joe", 1);

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_Save_SaveToDatabase()
    {
      //Arrange
      Client testClient = new Client("Joe", 1);
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
      Client testClient = new Client("Joe", 1);

      testClient.Save();
      int actual = Client.GetAll()[0].GetId();
      int expected = testClient.GetId();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Find_FindClientInDatabaseById()
    {
      Client testClient = new Client("Joe", 1);

      testClient.Save();
      Client actual = Client.Find(testClient.GetId());

      Assert.Equal(testClient, actual);
    }

    [Fact]
    public void Test_Delete_DeleteClientInDatabase()
    {
      Client.DeleteAll();
      Client testClient = new Client("Joe", 1);
      testClient.Save();

      testClient.Delete();
      List<Client> expected = new List<Client>{};
      List<Client> actual = Client.GetAll();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Update_UpdateClientNameInDatabase()
    {
      Client testClient = new Client("Joe", 1);
      testClient.Save();

      testClient.Update("Roy");
      List<Client> expected = new List<Client>{testClient};
      List<Client> actual = Client.GetAll();

      Assert.Equal(expected, actual);
    }
  }
}
