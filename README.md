# Fire In The Salad Kingdom

COMMIT MESSAGES SHOULD BE HELPFUL

General Unity Rules:

-NEVER Change a Scene Which you have pulled. If you want to edit it, make a copy and edit the copy

-Be careful when changing folders and locations, make sure you run 

    git status
 
 to check that the changes of location will not only add to the new location but remove from the previous
location

Branches:

A stable build is one which has been well-tested and does not crash under a good amount of stress
A submittable build is one which we would be ok with turning in at the end of this thing

-NEVER commit to Master  --> This is only for builds that are stable and submittable

-Only commit to dev when the build with your new feature is stable --> This is for builds which are stable, but not submittable

-Each time you are making a new feature, work in a new branch using a gui tool or via
    
    git checkout -b <branch-name>
    
 --> This is for builds which are neither stable nor submittable


