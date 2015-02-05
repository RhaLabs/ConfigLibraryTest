/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/20/2014
 * Time: 2:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibraryTest.Configuration
{
  /// <summary>
  /// Description of Configuration.
  /// </summary>
  public sealed class Configuration : ConfigLibrary.Configuration
  {
    public Configuration()
    {
      database = new ConfigLibraryTest.Entity.DataBaseEntity();
      mail = new ConfigLibraryTest.Entity.MailEntity();
      list = new ConfigLibraryTest.Entity.CollectionEntity();
      
      mapping = new Entity.EnumMapping();
    }
    
    private Entity.EnumMapping mapping;
    
    public System.Collections.Generic.Dictionary< int, Entity.Mapping > Mapping
    {
      get { return this.mapping.Mapping; }
      set { this.mapping.Mapping = value; }
    }
  }
}
