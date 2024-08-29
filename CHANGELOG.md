## [1.1.1] - 2024-08-29
### Resolved Method Name Conflicts
#### Change:
Resolved method name conflicts of the following methods:
1. **Conflict:** ```TripleA.Extensions.Vector3.Set``` with ```UnityEngine.Vector3.Set```<br>
Changed method name to ```Vector3.SetThis```

<details>
  <summary> <b>Example Usage:</b> </summary>
  Old:<br>
  <code>
    Vector3 v = new Vector3(1, 2, 3);  // Value of v = (1,2,3)
  </code><br>
  <code>v.Set(y:0, z:0);                   // Sets the value of v to (1,0,0)
  </code>

  New:<br>
  <code>
    Vector3 v = new Vector3(1, 2, 3);  // Value of v = (1,2,3)
  </code><br>
  <code>
    v.SetThis(y: 0,z: 0);              // Sets the value of v to (1,0,0)
  </code>
</details>

2. **Conflict:** ```TripleA.Extensions.Vector2.Set``` with ```UnityEngine.Vector2.Set```<br>
  Changed method name to ```Vector2.SetThis```

<details>
  <summary> <b>Example Usage:</b> </summary>
  Old:<br>
  <code>
    Vector2 v = new Vector2(1, 2);  // Value of v = (1,2)
  </code><br>
  <code>
    v.Set(y:0);                     // Sets the value of v to (1,0)
  </code>

  New:<br>
  <code>
    Vector3 v = new Vector3(1, 2, 3);  // Value of v = (1,2,3)
  </code><br>
  <code>
    v.SetThis(y: 0,z: 0);              // Sets the value of v to (1,0,0)
  </code>
</details>

## [1.1.0] - 2024-08-24
### New Event System and Observables Update
#### Add:
- Commonly Used Observable Datatypes : ```ObservableInt, ObservableFloat, ObservableBool```
- Commonly Used Observable Collection : ```ObservableQueue, ObservableStack```
- New Event Channel System

#### Change:
- Moved ```Observable<T>``` to new file named GenericObservable.cs

> NO CHANGES IN API

___

## [1.0.0] - 2024-08-16
### First Release
- Extension methods for unity
- Timer that uses low level unity player loop system for timers