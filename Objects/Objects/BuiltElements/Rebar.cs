﻿using Objects.Geometry;
using Objects.Utils;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Objects.Structural.Materials;

namespace Objects.BuiltElements
{
  public class Rebar : Base, IDisplayMesh, IHasVolume
  {
    public List<ICurve> curves { get; set; } = new List<ICurve>();

    [DetachProperty]
    public Mesh displayMesh { get; set; }

    public string units { get; set; }
    public double volume { get; set; }

    public Rebar() { }
  }
}

namespace Objects.BuiltElements.TeklaStructures
{
  public class TeklaRebar : Rebar
  {
    public string name { get; set; }
    public Hook startHook { get; set; }
    public Hook endHook { get; set; }
    public double classNumber { get; set; }
    public string size { get; set; }
    public Material material { get; set; }
  }
  public class Hook{
    public double angle { get; set; }
    public double length { get; set; }
    public double radius { get; set; }
    public shape shape { get; set; }
  }
  public enum shape
  {
    NO_HOOK = 0,
    HOOK_90_DEGREES = 1,
    HOOK_135_DEGREES = 2,
    HOOK_180_DEGREES = 3,
    CUSTOM_HOOK = 4
  }

}
namespace Objects.BuiltElements.Revit
{
  public class RevitRebar : Rebar
  {
    public string family { get; set; }
    public string type { get; set; }
    public string host { get; set; }
    public string barType { get; set; }
    public string barStyle { get; set; }
    public List<string> shapes { get; set; }
    public Base parameters { get; set; }
    public string elementId { get; set; }

    public RevitRebar() { }

  }
}
