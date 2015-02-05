/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 8/7/2014
 * Time: 4:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibraryTest.Entity
{
  /// <summary>
  /// Description of MailBox.
  /// </summary>
  public class MailBox : ConfigLibrary.Entity.MailBox, ConfigLibrary.Entity.EntityInterface
  {
    public MailBox()
    {
      folders = new System.Collections.Generic.List< string >();
    }
  }
}
