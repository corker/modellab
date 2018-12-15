using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ModelLab.Graphs;
using ModelLab.Sessions;

namespace ModelLab.Algorithms
{
    public class RandomAlgorithm : ISelectEdges
    {
        private readonly byte[] _buffer = new byte[2];
        private readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

        public IAmEdge Select(IEnumerable<IAmEdge> edges)
        {
            return edges
                .Select(x => new
                {
                    Weight = Random(),
                    Edge = x
                })
                .OrderByDescending(x => x.Weight)
                .Select(x => x.Edge)
                .First();
        }

        private ushort Random()
        {
            _rng.GetBytes(_buffer);
            return BitConverter.ToUInt16(_buffer, 0);
        }
    }
}