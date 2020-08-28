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

        /// <summary>
        /// This event is raised when a marker was added to the collection or if a marker was removed.
        /// </summary>
        public event EventHandler<MarkerCollectionEventArgs> MarkerCollectionChanged;

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
                    RemoveFirstMarker();
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
        public void AddMarker(Point pos, int limit, bool verticalOnly = false)
        {
            // Add the marker as horizontal or vertical marker based on position
            bool vertical = verticalOnly || pos.Y >= limit;
            Marker newMarker;
            if (vertical)
                newMarker = new Marker(pos.Y, true);
            else newMarker = new Marker(pos.X, false);
            Markers.AddLast(newMarker);
            // remove first if we hit limit
            if (Markers.Count > Limit)
                RemoveFirstMarker();
            MarkerCollectionChanged?.Invoke(this, new MarkerCollectionEventArgs(true, newMarker));
        }

        /// <summary>
        /// Returns the closest marker within a specified window if available.
        /// </summary>
        /// <param name="pos">The search location.</param>
        /// <param name="diff">The search window size.</param>
        /// <returns>The found marker if available, a default marker otherwise.</returns>
        public Marker GetMarker(Point pos, int limit, int diff = 2)
        {
            Marker marker = Marker.Default;
            // first search horizontal markers, then vertical markers
            if (pos.Y < limit)
            {
                marker = Markers.Where((v) => Math.Abs(pos.X - v.Value) <= diff).FirstOrDefault();
            }
            if (marker == Marker.Default)
            {
                return Markers.Where((v) => Math.Abs(pos.Y - v.Value) <= diff).FirstOrDefault();
            }
            return marker;
        }

        public void RemoveMarker(Marker marker)
        {
            Markers.Remove(marker);
            MarkerCollectionChanged?.Invoke(this, new MarkerCollectionEventArgs(false, marker));
        }

        public void RemoveFirstMarker()
        {
            var first = Markers.First.Value;
            Markers.RemoveFirst();
            MarkerCollectionChanged?.Invoke(this, new MarkerCollectionEventArgs(false, first));
        }

        public void Clear()
        {
            var removedItems = Markers.ToArray();
            Markers.Clear();
            MarkerCollectionChanged?.Invoke(this, new MarkerCollectionEventArgs(false, removedItems));
        }
    }

    public class MarkerCollectionEventArgs : EventArgs
    {
        public Marker[] AddedMarkers { get; }
        public Marker[] RemovedMarkers { get; }

        public MarkerCollectionEventArgs(bool isAdded, params Marker[] changedMarkers)
        {
            if (isAdded) AddedMarkers = changedMarkers;
            else RemovedMarkers = changedMarkers;
        }
    }
}
