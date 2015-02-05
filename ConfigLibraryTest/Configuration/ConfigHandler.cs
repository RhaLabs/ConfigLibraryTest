/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 8/7/2014
 * Time: 4:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft.Json;

namespace ConfigLibraryTest.Configuration
{
  /// <summary>
  /// Description of ConfigHandler.
  /// </summary>
  public class ConfigHandler : ConfigLibrary.ConfigHandler
  {
    private Configuration config;
    
    public ConfigHandler()
      : this(@".\\config.json")
    {
      
    }
    
    public ConfigHandler(string path)
      : base(path)
    {
      
      config = JsonConvert.DeserializeObject< Configuration >(jsonString);

      configuration = config;
    }
    
    public System.Collections.Generic.Dictionary< int, Entity.Mapping > Mapping
    {
      get { return this.config.Mapping; }
      set { this.config.Mapping = value; }
    }
  }
}