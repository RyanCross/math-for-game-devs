﻿using UnityEditor;

// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/
namespace Shapes {

	[CustomEditor( typeof(Torus) )]
	[CanEditMultipleObjects]
	public class TorusEditor : ShapeRendererEditor {

		SerializedProperty propRadius = null;
		SerializedProperty propRadiusSpace = null;
		SerializedProperty propThickness = null;
		SerializedProperty propThicknessSpace = null;

		public override void OnInspectorGUI() {
			base.BeginProperties();
			ShapesUI.FloatInSpaceField( propRadius, propRadiusSpace );
			ShapesUI.FloatInSpaceField( propThickness, propThicknessSpace );
			base.EndProperties();
		}

	}

}