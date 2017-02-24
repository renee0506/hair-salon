using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClinet;

namespace HairSalon
{
  public class ClientsTest: IDisposable
  {
    public ClientsTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    // public void Dispose()
    // {
    //   Clients.DeleteAll();
    // }

    [Fact]
    public void Test_ClientsTableEmptyAtFirst()
    {
      //Arrange Act
      int result = Clients.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
  }
}
