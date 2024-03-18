using System;
using Managers.Minimax;
using Pieces;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;


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
            Debug.Log("Starting Minimax");
            Node startingNode = new Node(GameManager.Instance.BoardMatrix, playerTurn, playerTurn);
            Node bestChild = null;
            foreach (Node child in startingNode.GetChilds())
            {
                MinMax(startingNode, depth, true);
                if (bestChild == null || child.GetHeuristic() > bestChild.GetHeuristic())
                    bestChild = child;
                else if (child.GetHeuristic() == bestChild.GetHeuristic() && Random.Range(0f, 1f) > 0.5)
                    bestChild = child;
            }
            PlayTurn(new Node(bestChild.CurrentBoard, bestChild.OwnerColor, bestChild.TurnColor));
        }

        private float MinMax(Node node, int minMaxDepth, bool maximizingPlayer) {
            //Debug.Log(minMaxDepth);
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

        private void PlayTurn(Node bestChild)
        {
            GameManager.Instance.BoardMatrix = bestChild.CurrentBoard;
            foreach (GameObject pieceGameObject in GameManager.Instance.PiecesGameObject)
            {
                Destroy(pieceGameObject);
            }
            GameManager.Instance.DisplayMatrix();
            GameManager.Instance.FirstTurn = false;
            //Changement tour
            switch (GameManager.Instance.WhiteTurn)
            {
                case true:
                    GameManager.Instance.WhiteTurn = false;
                    break;
                case false:
                    GameManager.Instance.WhiteTurn = true;
                    break;
            }
            _isThinking = false;
        }
    }
}
