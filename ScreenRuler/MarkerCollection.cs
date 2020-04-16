using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace ScreenRuler
{
    [Serializable]
    public class MarkerCollection
    {
        private int limit = int.MaxValue;

        public MarkerCollection()
        {
            Markers = new LinkedList<Marker>();
        }

        [XmlIgnore]
        public int Limit
        {
            get => limit;
            set
            {
                limit = value;
                // remove additional markers
                while (Markers.Count > limit)
                    Markers.RemoveFirst();
            }
        }

        [XmlIgnore]
        public LinkedList<Marker> Markers { get; private set; }

        // String property used for serialization
        [XmlElement("Markers")]
        public string MarkersString
        {
            get => String.Join(",", Markers);
            set
            {
                Markers = new LinkedList<Marker>(
                    value.Split(',').Where(s => !String.IsNullOrWhiteSpace(s))
                                    .Select(s => Marker.FromString(s))
                    );
            }
        }

        public IEnumerable<Marker> Horizontal => Markers.Where(m => !m.Vertical);

        public IEnumerable<Marker> Vertical => Markers.Where(m => m.Vertical);

        /// <summary>
        /// Adds a marker to the collection based on its location on the ruler form.
        /// </summary>
        /// <param name="pos">The location of the marker.</param>
        public void AddMarker(Point pos, bool verticalOnly = false)
        {
            // Add the marker as horizontal or vertical marker based on position
            bool vertical = verticalOnly || pos.Y >= RulerPainter.RULER_WIDTH;
            if (vertical)
                Markers.AddLast(new Marker(pos.Y, true));
            else Markers.AddLast(new Marker(pos.X, false));
            // remove first if we hit limit
            if (Markers.Count > Limit)
                Markers.RemoveFirst();
        }

        /// <summary>
        /// Returns the closest marker within a specified window if available.
        /// </summary>
        /// <param name="pos">The search location.</param>
        /// <param name="diff">The search window size.</param>
        /// <returns>The found marker if available, a default marker otherwise.</returns>
        public Marker GetMarker(Point pos, int diff = 2)
        {
            if (pos.Y < RulerPainter.RULER_WIDTH)
            {
                return Markers.Where((v) => Math.Abs(pos.X - v.Value) <= diff).FirstOrDefault();
            }
            else
            {
                return Markers.Where((v) => Math.Abs(pos.Y - v.Value) <= diff).FirstOrDefault();
            }
        }
    }
}
