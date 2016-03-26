using System.Collections.Generic;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeWKT
{
	/* ESRI's Geometry class has an Internal constructor   */
	/* so we can't subclass it ourselves                   */
	/* this is a placeholder for some later-day workaround */

	public class GeometryCollection : List<Geometry>
	{
		public Envelope Extent
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
