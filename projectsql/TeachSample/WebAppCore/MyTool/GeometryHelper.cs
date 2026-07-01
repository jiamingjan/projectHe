//using System.Data.Entity.Spatial;
using System.Globalization;

namespace MyTool
{
    public class GeometryHelper
    {
        //public static DbGeometry CreatePoint(double longitude, double latitude)
        //{
        //    var text = string.Format(CultureInfo.InvariantCulture.NumberFormat, "POINT({0} {1})", longitude, latitude);

        //    // 4326 is most common coordinate system used by GPS/Maps            
        //    return DbGeometry.PointFromText(text, 4326);
        //}

        public static bool ReadLonLatFromString(ref decimal longitude, ref decimal latitude, string geom)
        {
            if (string.IsNullOrEmpty(geom))
                return false;
            if (!geom.ToUpper().Contains("POINT"))
                return false;
            int start = geom.IndexOf('(');
            int end = geom.IndexOf(')');
            string str = geom.Substring(start + 1, end- start -1);
            string[] data = str.Split(' ');
            if (data.Length == 2)
            {
                longitude = decimal.Parse(data[0]);
                latitude = decimal.Parse(data[1]);
                return true;
            }
            return false;
        }
    }  
}
