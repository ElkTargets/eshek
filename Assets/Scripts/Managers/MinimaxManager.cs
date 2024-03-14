using Managers.Minimax;
using Pieces;
using UnityEngine;
using Utils;


namespace Managers
{
    public class MinimaxManager : MonoBehaviourSingleton<MinimaxManager>
    {
        public int depth;
        public Color playerTurn;
        private bool _isThinking;
        private Node _choosedNode;

        [ContextMenu("Think")]
        public void Think() {
            if (_isThinking) return;
            _isThinking = true;
            if (GameManager.Instance.WhiteTurn) { playerTurn = Color.white; }
            else { playerTurn = Color.black; }
            Node startingNode = new Node(GameManager.Instance.BoardMatrix, playerTurn);
            MinMax(startingNode, depth, true); 
            //PlayTurn();
        }

        private float MinMax(Node node, int minMaxDepth, bool maximizingPlayer) {
            Debug.Log(minMaxDepth);
            if (minMaxDepth == 0 || node.IsTerminal()) return node.GetHeuristic();
            float minMaxValue;
            if (maximizingPlayer) {
                minMaxValue = Mathf.NegativeInfinity;
                foreach (Node childNode in node.GetChilds()) {
                    minMaxValue = Mathf.Max(minMaxValue, MinMax(childNode, minMaxDepth - 1, false));
                }
                Debug.Log(minMaxValue);
            }
            else {
                minMaxValue = Mathf.Infinity;
                foreach (Node childNode in node.GetChilds()) {
                    minMaxValue = Mathf.Min(minMaxValue, MinMax(childNode, minMaxDepth - 1, true));
                }
                Debug.Log(minMaxValue);
            }
            return minMaxValue;
        }

        /*private void PlayTurn(Board realBoard)
        {
            GameManager.Instance.
        }*/
    }
}
