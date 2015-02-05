/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 8/12/2014
 * Time: 8:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibraryTest.Entity
{
  /// <summary>
  /// Description of EnumMapping.
  /// </summary>
  public class EnumMapping
  {
    public EnumMapping()
    {
      map = new System.Collections.Generic.Dictionary< int, Mapping >();
    }
    
    protected System.Collections.Generic.Dictionary< int, Mapping > map;
    
    public System.Collections.Generic.Dictionary< int, Mapping > Mapping
    {
      get { return this.map; }
      set { this.map = value; }
    }
  }
  
  public enum Mapping
  {
    First,
    Second,
    Last
  }
}
