using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class RejectionSampler {
        public RejectionSampler(int width, int height, float minDistance, int maxTries, int seed) {
            _width = width;
            _height = height;
            _minDistance = minDistance;
            _maxTries = maxTries;
            _rand = new Random(seed);
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

        public bool TrySample(out Vector2 sample) {
            Vector2? triedSample = Sample();

            if (triedSample == null) {
                sample = new Vector2(0);
                return false;
            }
            else {
                sample = (Vector2)triedSample;
                return true;
            }
        }

        int _width;
        int _height;
        float _minDistance;
        int _maxTries;

        Random _rand;
        List<Vector2> _existingPoints = new List<Vector2>();
    }
}
