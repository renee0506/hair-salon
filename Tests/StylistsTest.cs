using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void Test_StylistTableEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_EqualOverrideTrueIfStylistNameAgeBioSame()
    {
      Stylist firstStylist = new Stylist("Joe", 24, "5 years in the Industry");
      Stylist secondStylist = new Stylist("Joe", 24, "5 years in the Industry");

      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test_Save_SaveToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Joe", 24, "5 years in the Industry");
      //Act
      testStylist.Save();
      List<Stylist> expected = new List<Stylist>{testStylist};
      List<Stylist> actual = Stylist.GetAll();
      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Save_AssignedIdToStylist()
    {
      Stylist testStylist = new Stylist("Joe", 24, "5 years in the Industry");

      testStylist.Save();
      int actual = Stylist.GetAll()[0].GetId();
      int expected = testStylist.GetId();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_Find_FindStylistInDatabaseById()
    {
      Stylist testStylist = new Stylist("Joe", 24, "5 years in the Industry");

      testStylist.Save();
      Stylist actual = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, actual);
    }

    [Fact]
    public void Test_GetClients_GetClientsThatBelongToOneStylist()
    {
      Stylist testStylist = new Stylist("Joe", 24, "5 years in the Industry");
      testStylist.Save();

      Client firstClient = new Client("Roy", testStylist.GetId());
      Client secondClient = new Client("Jeff", testStylist.GetId());
      Client thirdClient = new Client("Kay", testStylist.GetId());

      firstClient.Save();
      secondClient.Save();
      thirdClient.Save();

      List<Client> expected = new List<Client> {firstClient, secondClient, thirdClient};
      List<Client> actual = testStylist.GetClients();

      Assert.Equal(expected, actual);
    }
  }
}
