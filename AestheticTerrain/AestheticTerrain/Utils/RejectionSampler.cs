using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain.Utils {
    class RejectionSampler {
        public RejectionSampler(int width, int height, float minDistance, int maxTries) {
            _width = width;
            _height = height;
            _minDistance = minDistance;
            _maxTries = maxTries;
        }

        public Vector2i? Sample() {
            int tries = 0;
            bool validSample = false;

            while (tries < _maxTries && !validSample) {
                Vector2 newSample = new Vector2(_rand.Next(_width), _rand.Next(_height));
                float leastDist = float.MaxValue;

                foreach (var point in _existingPoints) {
                    float dist = Vector2.Distance(newSample, point);
                    if (leastDist > dist) leastDist = dist;
                }

                if (leastDist > _minDistance || _existingPoints.Count == 0) {
                    _existingPoints.Add(newSample);
                    return new Vector2i((int)newSample.X, (int)newSample.Y);
                }
            }

            return null;
        }

        int _width;
        int _height;
        float _minDistance;
        int _maxTries;

        Random _rand = new Random();
        List<Vector2> _existingPoints = new List<Vector2>();
    }
}
