/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/13/2014
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using ConfigLibrary;
using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ConfigLibraryTest
{
[TestFixture]
  class ConfigTest
  {
    private string mailhost = "localmail";
    
    private string mailuser = "Good Guy Mail";
    
    private int mailport = 25;
    
    private string mailpass = "SecretMail";
    
    private string datahost = "localdata";
    
    private string datauser = "Good Guy Data";
    
    private string database = "db";
    
    private int dataport = 3306;
    
    private string datapass = "SecretData";
    
    private System.Collections.Generic.Dictionary< string, string > Addresses;
    
    private System.Collections.Generic.List< ConfigLibraryTest.Entity.MailBox > Mailboxes;
    
    [Test]
    public void TestConfigHandler ()
    {
      var handler = new ConfigLibraryTest.Configuration.ConfigHandler();
      
      Assert.That(handler, Is.InstanceOf<ConfigHandler>());
    }
    
    [SetUp]
    [Test]
    public void TestConfigHandler_WriteFileName()
    {
      var handler = new ConfigLibraryTest.Configuration.ConfigHandler();
      
      //      Addresses = new System.Collections.Generic.Dictionary<string, string> {
      //        { "email1", "1@email.com" },
      //        { "email2", "2@email.com" },
      //        { "email3", "3@email.com" }
      //      };

      var mailbox1 = new ConfigLibraryTest.Entity.MailBox();
      
      mailbox1.Address = "1@email.com";
      mailbox1.Folders = new System.Collections.Generic.List<string> { "box1 test1", "box1 test2", "box1 test3" };
      
      var mailbox2 = new ConfigLibraryTest.Entity.MailBox();
      
      mailbox2.Address = "2@email.com";
      mailbox2.Folders = new System.Collections.Generic.List<string> { "box2 test1", "box2 test2", "box2 test3" };

      var mailbox3 = new ConfigLibraryTest.Entity.MailBox();
      
      mailbox3.Address = "3@email.com";
      mailbox3.Folders = new System.Collections.Generic.List<string> { "box3 test1", "box3 test2", "box3 test3" };
      
      Mailboxes = new System.Collections.Generic.List< ConfigLibraryTest.Entity.MailBox > {
       mailbox1, mailbox2, mailbox3
      };
      
      string path = @".\\test.json";
      
      handler.AddMailInfo(mailhost, mailuser, mailpass, mailport);
      handler.AddSqlInfo(datahost,datauser, datapass, database, dataport);
      handler.MailBoxes = this.Mailboxes;
      
      
      
      handler.SaveConfig(path);
      
      Assert.IsNotEmpty(System.IO.File.ReadAllText(@".\\test.json"));
    }
    
    [Test]
    public void TestConfigHandler_Write()
    {
      var handler = new ConfigLibraryTest.Configuration.ConfigHandler();
      
      handler.SaveConfig();
      
      Assert.IsNotEmpty(System.IO.File.ReadAllText(@".\\config.json"));
    }
    
    [Test]
    public void ReadJson ()
    {
      string path = @".\\test.json";
      
      ConfigHandler handler = new ConfigLibraryTest.Configuration.ConfigHandler(path);
      
      Assert.That(handler.MailHost, Is.EqualTo(mailhost));
      Assert.That(handler.MailPass, Is.EqualTo(mailpass));
      Assert.That(handler.MailUser, Is.EqualTo(mailuser));
      Assert.That(handler.MailPort, Is.EqualTo(mailport));
      Assert.That(handler.SqlDatabase, Is.EqualTo(database));
      Assert.That(handler.SqlHost, Is.EqualTo(datahost));
      Assert.That(handler.SqlPass, Is.EqualTo(datapass));
      Assert.That(handler.SqlPort, Is.EqualTo(dataport));
      Assert.That(handler.SqlUser, Is.EqualTo(datauser));
    }
    
    [Test]
    public void ReadMailBoxesFromJson ()
    {
      string path = @".\\test.json";
      
      var handler = new ConfigLibraryTest.Configuration.ConfigHandler(path);
      
      var folders = handler.MailBoxes.ToList().Find( x => x.Address == "2@email.com" ).Folders;
      
      Assert.That( folders.Count, Is.EqualTo(3) );
      
      Assert.That( folders.Exists( x => x == "box2 test2" ), Is.True );
    }
  }
}