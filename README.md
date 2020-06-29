#Cell Path Creator

Tool for animating 3d model of cell along a series of paths

##Usage

Add the desired number of Cell prefabs to the scene. Customize the cell's color
and rotation in the inspector

For each Cell in the scene, add the desired number of CellPath objects to the
scene. CellPaths can be modified by moving the childed ControlPoints. Add
the CellPaths to the Path parameter of the Cell's PathFollow Path Parameter.
A Cell can have any number of paths. Each Cell should have its own set of 
unique CellPaths with separate transforms so that the Cells are not animated
directly on top of each other.

###Credits

Cubic bezier formula adapted courtesy of 
https://en.wikipedia.org/wiki/B%C3%A9zier_curve#Cubic_B%C3%A9zier_curves

Path visualization in inspector courtesy of Alexander Zotov
https://www.youtube.com/watch?v=11ofnLOE8pw



