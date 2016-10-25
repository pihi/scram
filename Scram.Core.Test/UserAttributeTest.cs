using Scram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scram.Core.Test
{
  public class UserAttributeTest
  {
    [Fact]
    public void WillEscapeEqualSignInToString()
    {
      var expected = "n=ThisIs=3DMyUsername";
      var attr = new UserAttribute("ThisIs=MyUsername");
      Assert.Equal("ThisIs=MyUsername", attr.Value);
      Assert.Equal(expected, attr.ToString());
    }

    [Fact]
    public void WillReplaceEscapedEqualSignWhenFromWire()
    {
      var attr = new UserAttribute("ThisIs=3DMyUsername", true);
      Assert.Equal("ThisIs=MyUsername", attr.Value);
    }

    [Fact]
    public void WillThrowWhenUnescapedEqualExistsInContentFromWire()
    {
      Assert.Throws<FormatException>(() => new UserAttribute("ThisIs=MyUsername", true));
    }
    
    [Fact]
    public void WillEscapeCommaInToString()
    {
      var expected = "n=ThisIs=2CMyUsername";
      var attr = new UserAttribute("ThisIs,MyUsername");
      Assert.Equal("ThisIs,MyUsername", attr.Value);
      Assert.Equal(expected, attr.ToString());
    }

    [Fact]
    public void WillReplaceEscapedCommaWhenFromWire()
    {
      var attr = new UserAttribute("ThisIs=2CMyUsername", true);
      Assert.Equal("ThisIs,MyUsername", attr.Value);
    }

    [Fact]
    public void WillReplaceMultipleEscapedValuesWhenFromWire()
    {
      var attr = new UserAttribute("This=3D=2CIs=2CMy=3DUsername", true);
      Assert.Equal("This=,Is,My=Username", attr.Value);
    }
  }
}
