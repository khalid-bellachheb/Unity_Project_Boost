# Project Boost
## VCS : Version Control System
- git 
- Mercurial
- Perforce

## Some Version Control Jargon
- Repository
- Commit
- SourceTree is GUI
- GitHub / Bitbucket host repos remotely online

## 41. The Origin Of Our World
 - which axis is Which : 
  - +x = right
  - +y = up
  - +z = forward
  ### Setup your World
   - Your ground level is at y=0.  #Done
   - the launchpad is centered on x=0, z=0. #Done
   - you have an intial camera view you like. #Done
   - Everything is the Hierarchy is "prefabbed" #Done
   - You have assigned terrain colour. #Done
   - You've modified the directional light rotation. #Done
   - You have shared a screenshot.

## 42. Placeholder Art From Primitives
### Setting-up Compound Objects
   - Keep mesh away from top-level [Parent GameObject] so easy to swap.
   - Keep top-level object scale close to (1,1,1).
   - Beware of Pivot/ center option (`#` Z key)
   - Ckeck objects rotates, scales and instantiates ok.
### Shortcut KeyWord
   - `#` Ctrl + SHift : Translate Mode
   - `#` (Ctrl + h/r) * 2 : Refactoriser 


## 43. Basic Input Binding
- Acces key keyboard 
### Rigid body component
   - Add physics propreties to our GameObject
### Vertual Input layer / cross platform input
   - Use the Input library from unity

## 44. Physics and RigidBodies
   - Use advanced c# function : generics
   - Acces to RigidBody Component with GetComponent Method

## 45. Cordinate System Handedness
   - Use right hand to simulate rotation on scripting 

## 46. Using Time.deltaTime
### PlayeMode Tint
   - Edit -> Preferences -> colors
### Physics Engine

### Frame-rate Independence 
   - The time each frame takes can vary wildly
   - Time.deltaTime tells you the last frame time
   - This is a good prediction of the current frame time
   - We can use this to adjust our mouvement
   - Longer frames lead to more mouvement 
   - Shorter frames lead to less mouvement
   - e.g. "#" rotation = rcsThrust * Time.deltaTime.

## 50. Using SerialField VS Public
### PlayeMode Tint

## 91 difference between transform.position and transform.localposition
- position    The position of the transform in world space. 
- localPosition   Position of the transform relative to the parent transform.
