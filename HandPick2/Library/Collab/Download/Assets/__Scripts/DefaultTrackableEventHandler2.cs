/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections;
using TMPro;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler2 : MonoBehaviour,
                                            ITrackableEventHandler
    {
	    #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;
        //private Rect mButtonRect = new Rect(50, 50, 120, 60);

	    #endregion // PRIVATE_MEMBER_VARIABLES

	    #region UNTIY_MONOBEHAVIOUR_METHODS
	    //public displayitem item1;
	    void Start()
		{
	   
	    	mTrackableBehaviour = GetComponent<TrackableBehaviour>();
	        if (mTrackableBehaviour)
	        {
	            mTrackableBehaviour.RegisterTrackableEventHandler(this);
	        }
		}

    	#endregion // UNTIY_MONOBEHAVIOUR_METHODS
        #region PUBLIC_METHODS
        public bool nottracked = false;
        //  private const string label = "The <#0050FF>count is: </color>{0:2}";
        // private float m_frame;
        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
				if (nottracked == true)
                {
                    finditem.tracked = true;
                    displayitem.displayed = true;
                    //displayitem.Display
                    //mShowGUIButton = true;
                    nottracked = false;
                }
				OnTrackingFound();
            }
            else
            {
                displayitem.displayed = false;
                displayitem.removed = true;
                //item1.Removed();
                nottracked = true;
                OnTrackingLost();
        	}
        }

        #endregion // PUBLIC_METHODS
        #region PRIVATE_METHODS

        private void OnTrackingFound()
		{
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
			}

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }
        #endregion // PRIVATE_METHODS
	}
}