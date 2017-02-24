using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon
{
  public class ClientTest
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    // public void Dispose()
    // {
    //   Client.DeleteAll();
    // }

    [Fact]
    public void Test_ClientsTableEmptyAtFirst()
    {
      //Arrange Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
  }
}
