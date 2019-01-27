## Scheduler Algorithm FIFO - FIRST IN, FIRST OUT 
Abstract: This article has a goal to study Scheduler Algorithms and its properties, in special FIFO (First In First Out) by the implementation in console C#. This algorithm is the most basic for having a data structure, queue, that becomes simple to implement. Will be approach simulator features, as level, preemptive and priorities, beyond the objectives and detail explanation about its operation. Also, is approached the study about scheduler for network traffic and models of traffic, where some scheduler as Priority Queuing, Deficit Round Robin, Weighted Fair Queueing, 

Custon Queuing, Weighted Round Robin, Class Based Queuing e First Come First Out (First In First Out). 

Keywords: Algorithm, Scheduler, Process management. 

## Introduction  

Scheduler algorithms are a set of tools that decides execution order and manages the use of CPU. The scheduling tries to satisfy some performance conditions. Some of these conditions are complementary, but some conditions may compete with others. This scheduling policy is defined according to system objectives. This article contains a simple scheduler FIFO (First-in-First-Out), where the process sends happens per arrival order in a queue. Nevertheless, the scheduler doesn't ensure the existence of maximum limits to delay in the queue. Then, the flows that receive a smaller process after the biggest process decrease performance.
Therefore, the goal is to represent schedulers and analyze how the scheduler algorithm  FIFO works by its implementation, using process management, observing characteristics and performance, service time, system time and queue time. 

## Algorithm operation 
The algorithm implementation was realized at the C# console in Visual Studio IDE. 
To introduce FCFS (First Come, First Served) algorithm, the inputs and outputs must be defined first. The algorithm's intention is to introduce its functioning and,  some variables, in the execution context, were changed or ignored. The method that executes the process, for example, was appended an algorithm to simulate runtime, based on a quantity of subprocesses, in order to guarantee a demonstration of the difference between runtimes, the way that scheduler deal with this kind of situation and make easy to view, seeing as all the processing run less than milliseconds to accomplish.

Inputs :
   - Quantity of process
   - Quantity of Subprocess 
    - Process time arrival in a queue

Outputs:
   - Hour of beginning - Queue's begins 
   - Time elapsed
   - Processes ready        
   - Process in execution
   - Process in wait 
   - Turnaround - Total time since an arrival until the end of execution
   - Average waiting time

## Simulator on Console
At the beginning of execution, the program requires a quantity of process to be executed. These processes are stored inside of an array on Queue class, and time random is sorted as a time of process' arrival on the queue. Then, the program sets the processes by arrival' order. As already said, subprocesses added on a process appends the process' runtime. 
In case that hasn't any subprocesses to be added, the program starts execution. The date and hour of queue's beginning are shown and then shows the process to be executed first and its data: the hour of execution's beginning,  time of process' arrival, the hour of execution's final, runtime, waiting time and turnaround.
Take a look at the process where were added a subprocess has a time of execution in 5 seconds, while the others have an equivalent runtime in 2 seconds. Another point to note, the last process has a waiting time bigger, that happens because at the queue 's beginning was defined that receiver all the process until the firsts fifteen seconds. 

## Code 
The method of AddProcess() is responsible for add a quantity of process in the queue. Inside the Queue class, this quantity is stored in the attribute of the queue (nProcess) and is used to other methods that through the array listProcess. The same method call another method, BubbleSort, to order the process based on arrival's order. 
With the processes and subprocess added, the method QueueStartTime() is called by the main program, that starts the time of queue's beginning and triggers the method executeProcess(). 
This second method shows the queue's beginning and through queue's items. The processes are started after the arrival's time, that is controlled by a timer, and then, the method SimulateProcess() gives progress to an algorithm to return runtime in seconds. 
To exhibition, still in the execution method, is calculated the runtime, results of the difference between the time of process' final and process' beginning, and waiting time, results of total queue' time subtracting the turnaround. The turnaround is calculated by the sum of runtime and arrival's time of the process.