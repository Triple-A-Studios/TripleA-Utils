## [1.1.1] - 2024-08-27
### Namespace Change, Method name Change
#### Change:
- Root namespace from ```TripleA``` to ```Utils.TripleA```.
- Changed Vector3 and Vector2 Extension method ```Set``` to ```SetThis```.

Both changes example:

Old code :
```C#
using TripleA.Extensions;
using UnityEngine;

namespace Example {
    public class Test {
        public void TestMethod() {
            Vector3 vec = new Vector3(1, 2, 3);
            vec.Set(4, 5, 6); // sets the vector to (4, 5, 6)
        }
    }
}
```

New code :
```C#
using Utils.TripleA.Extensions;
using UnityEngine;

namespace Example {
    public class Test {
        public void TestMethod() {
            Vector3 vec = new Vector3(1, 2, 3);
            vec.SetThis(4, 5, 6); // sets the vector to (4, 5, 6)
        }
    }
}
```

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