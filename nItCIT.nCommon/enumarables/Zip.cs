using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class Zip
    {

        static public IEnumerable<Pair<TElem>> TwoSequencesOfSameType<TElem>(IEnumerable<TElem> elementsA, IEnumerable<TElem> elementsB)
        {

            return Enumerable
                .Zip(elementsA, elementsB, (xA, xB) => new Pair<TElem>(xA, xB));
        }

        static public IEnumerable<Pair<TElemA, TElemB>> TwoSequences<TElemA, TElemB>(IEnumerable<TElemA> elementsA, IEnumerable<TElemB> elementsB)
        {

            return Enumerable
                .Zip(elementsA, elementsB, (xA, xB) => new Pair<TElemA, TElemB>(xA, xB));                        
        }
    }
}
