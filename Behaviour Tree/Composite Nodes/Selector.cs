using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node {

    // Child nodes for this Selector
    private List<Node> m_childNodes = new List<Node>();

    // Constructor (takes List of child Nodes)
    public Selector(List<Node> childNodes) {
        m_childNodes = childNodes;
    }

    /// <summary>
    /// Takes a new List of child Nodes and replaces the current List with it.
    /// </summary>
    /// <param name="newChildNodes">The List<Node> of new child Nodes.</param>
    public void UpdateChildNodes(List<Node> newChildNodes) {
        m_childNodes = newChildNodes;
    }
    
    /// <summary>
    /// Returns Success if any child nodes returns Success. Returns Failure otherwise.
    /// </summary>
    /// <returns>NodeStates Success, Failure, or Running.</returns>
    public override NodeStates Evaluate() {
        // Loop through child nodes in order until Success or Running encountered
        foreach (Node node in m_childNodes) {
            switch(node.Evaluate()) {
                case NodeStates.FAILURE:
                    continue;
                case NodeStates.SUCCESS:
                    m_nodeState = NodeStates.SUCCESS;
                    return m_nodeState;
                case NodeStates.RUNNING:
                    m_nodeState = NodeStates.RUNNING;
                    return m_nodeState;
                default:
                    continue;
            }
        }
        // All child nodes returned Failure
        m_nodeState = NodeStates.FAILURE;
        return m_nodeState;
    }
}
