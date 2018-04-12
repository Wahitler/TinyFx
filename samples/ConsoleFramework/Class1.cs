
=====================================
2017-12-12 14:37:10 7fe83cbff700 INNODB MONITOR OUTPUT
=====================================
Per second averages calculated from the last 32 seconds
-----------------
BACKGROUND THREAD
-----------------
srv_master_thread loops: 140425 srv_active, 0 srv_shutdown, 277 srv_idle
srv_master_thread log flush and writes: 140702
----------
SEMAPHORES
----------
OS WAIT ARRAY INFO: reservation count 241797
OS WAIT ARRAY INFO: signal count 2384314
Mutex spin waits 6047861, rounds 30677978, OS waits 48492
RW-shared spins 5691760, rounds 37264700, OS waits 150675
RW-excl spins 410561, rounds 10537588, OS waits 41895
Spin rounds per wait: 5.07 mutex, 6.55 RW-shared, 25.67 RW-excl
------------------------
LATEST DETECTED DEADLOCK
------------------------
2017-12-12 12:52:00 7fe8413ff700
*** (1) TRANSACTION:
TRANSACTION 1566787021, ACTIVE 0.004 sec inserting
mysql tables in use 1, locked 1
LOCK WAIT 4 lock struct(s), heap size 1184, 2 row lock(s)
LOCK BLOCKING MySQL thread id: 1359121638 block 1343037747
MySQL thread id 1343037747, OS thread handle 0x7fe8052fb700, query id 44731973 10.27.229.248 rduser update
INSERT INTO `drs_match_user` (`MatchID`, `RoomNum`, `UserID`, `MatchDate`, `ResetNum`, `RemainJiFen`, `SignupDate`, `ObtainJiFen`, `RankNum`, `PrizeDSF`) VALUE (637, 1, 31625, '2017-12-12 18:15:00 ', 0, 10000, '2017-12-12 12:52:00.160462', 0, 0, 0)
*** (1) WAITING FOR THIS LOCK TO BE GRANTED:
RECORD LOCKS space id 1574 page no 209 n bits 296 index `PRIMARY` of table `oscdb`.`drs_match_user` trx id 1566787021 lock mode S locks rec but not gap waiting
Record lock, heap no 127 PHYSICAL RECORD: n_fields 12; compact format; info bits 0
 0: len 8; hex 800000000000027d; asc        };;
 1: len 4; hex 80000001; asc     ;;
 2: len 8; hex 8000000000007b89; asc       { ;;
 3: len 6; hex 00005d6345ca; asc   ]cE ;;
 4: len 7; hex 9c000002260110; asc     &  ;;
 5: len 5; hex 999e5923c0; asc   Y# ;;
 6: len 4; hex 80000000; asc     ;;
 7: len 4; hex 80002710; asc   ' ;;
 8: len 5; hex 999e58cd00; asc   X  ;;
 9: len 4; hex 80000000; asc     ;;
 10: len 4; hex 80000000; asc     ;;
 11: len 4; hex 80000000; asc     ;;

*** (2) TRANSACTION:
TRANSACTION 1566787018, ACTIVE 0.005 sec starting index read
mysql tables in use 1, locked 1
8 lock struct(s), heap size 1184, 4 row lock(s), undo log entries 2
MySQL thread id 1359121638, OS thread handle 0x7fe8413ff700, query id 44731987 10.27.229.248 rduser updating
update drs_match set JoinBeanNum=JoinBeanNum+500,JoinPersonNum=JoinPersonNum+1 where MatchID=637
*** (2) HOLDS THE LOCK(S):
RECORD LOCKS space id 1574 page no 209 n bits 296 index `PRIMARY` of table `oscdb`.`drs_match_user` trx id 1566787018 lock_mode X locks rec but not gap
Record lock, heap no 127 PHYSICAL RECORD: n_fields 12; compact format; info bits 0
 0: len 8; hex 800000000000027d; asc        };;
 1: len 4; hex 80000001; asc     ;;
 2: len 8; hex 8000000000007b89; asc       { ;;
 3: len 6; hex 00005d6345ca; asc   ]cE ;;
 4: len 7; hex 9c000002260110; asc     &  ;;
 5: len 5; hex 999e5923c0; asc   Y# ;;
 6: len 4; hex 80000000; asc     ;;
 7: len 4; hex 80002710; asc   ' ;;
 8: len 5; hex 999e58cd00; asc   X  ;;
 9: len 4; hex 80000000; asc     ;;
 10: len 4; hex 80000000; asc     ;;
 11: len 4; hex 80000000; asc     ;;

*** (2) WAITING FOR THIS LOCK TO BE GRANTED:
RECORD LOCKS space id 2176 page no 10 n bits 104 index `PRIMARY` of table `oscdb`.`drs_match` trx id 1566787018 lock_mode X locks rec but not gap waiting
Record lock, heap no 35 PHYSICAL RECORD: n_fields 26; compact format; info bits 0
 0: len 8; hex 800000000000027d; asc        };;
 1: len 6; hex 00005d62794b; asc   ]byK;;
 2: len 7; hex 280004400a1a9a; asc (  @   ;;
 3: len 4; hex 80000001; asc     ;;
 4: len 8; hex 80000000001512a8; asc         ;;
 5: len 5; hex 999e5923c0; asc   Y# ;;
 6: len 4; hex 8000012c; asc    ,;;
 7: len 1; hex 80; asc  ;;
 8: len 4; hex 800001f4; asc     ;;
 9: len 4; hex 80000000; asc     ;;
 10: len 4; hex 80000000; asc     ;;
 11: len 4; hex 800001f4; asc     ;;
 12: len 4; hex 80000001; asc     ;;
 13: len 3; hex 312c32; asc 1,2;;
 14: len 4; hex 80002710; asc   ' ;;
 15: len 4; hex 800001f4; asc     ;;
 16: len 4; hex 80000000; asc     ;;
 17: len 4; hex 80000000; asc     ;;
 18: len 4; hex 80000001; asc     ;;
 19: len 30; hex e8bebee4babae8b59be9ab98e6898be59cba20e8b5a2323030e8af9de8b4; asc                       200     ; (total 31 bytes);
 20: len 4; hex 80000032; asc    2;;
 21: len 4; hex 80000001; asc     ;;
 22: len 4; hex 80000001; asc     ;;
 23: len 5; hex 999e58a012; asc   X  ;;
 24: len 4; hex 80000000; asc     ;;
 25: len 4; hex 80000000; asc     ;;

*** WE ROLL BACK TRANSACTION (1)
------------
TRANSACTIONS
------------
Trx id counter 1568224855
Purge done for trx's n:o < 1568224610 undo n:o < 0 state: running but idle
History list length 392
LIST OF TRANSACTIONS FOR EACH SESSION:
---TRANSACTION 422110397370472, not started
MySQL thread id 1359022511, OS thread handle 0x7fe83cbff700, query id 48671160 202.108.36.107 opt init
show  ENGINE INNODB status
---TRANSACTION 422110552217704, not started
MySQL thread id 1057894383, OS thread handle 0x7fe80173c700, query id 48667479 10.24.19.222 rduser cleaning up
---TRANSACTION 422110199693416, not started
MySQL thread id 1343086192, OS thread handle 0x7fe7fc73c700, query id 48525875 10.24.19.222 rduser cleaning up
---TRANSACTION 422109776439400, not started
MySQL thread id 923355304, OS thread handle 0x7fe817bff700, query id 48612652 10.27.229.248 rduser cleaning up
---TRANSACTION 422110451339368, not started
MySQL thread id 1359083779, OS thread handle 0x7fe8403be700, query id 48669618 10.24.19.222 rduser cleaning up
---TRANSACTION 422110283776104, not started
MySQL thread id 1040985995, OS thread handle 0x7fe835fff700, query id 48667281 10.27.5.0 rduser cleaning up
---TRANSACTION 422109738305640, not started
MySQL thread id 1057372282, OS thread handle 0x7fe8157ff700, query id 48663040 10.24.19.222 rduser cleaning up
---TRANSACTION 422110120202344, not started
MySQL thread id 1073780506, OS thread handle 0x7fe7fba79700, query id 48623162 10.27.5.0 rduser cleaning up
---TRANSACTION 422110581620840, not started
MySQL thread id 923143352, OS thread handle 0x7fe8017be700, query id 48126378 10.24.19.222 rduser cleaning up
---TRANSACTION 422110620203112, not started
MySQL thread id 1358955133, OS thread handle 0x7fe8023ff700, query id 48512634 10.27.229.248 rduser cleaning up
---TRANSACTION 422110678128744, not started
MySQL thread id 922976676, OS thread handle 0x7fe8047be700, query id 47380889 202.108.36.107 opt cleaning up
---TRANSACTION 422110203953256, not started
MySQL thread id 1359479969, OS thread handle 0x7fe8313ff700, query id 47768393 202.108.36.107 opt cleaning up
---TRANSACTION 422110393061480, not started
MySQL thread id 1342673850, OS thread handle 0x7fe7fdfbe700, query id 48668178 10.27.229.248 rduser cleaning up
---TRANSACTION 422110728814696, not started
MySQL thread id 1057641216, OS thread handle 0x7fe8052ba700, query id 48604897 10.24.19.222 rduser cleaning up
---TRANSACTION 422110082660456, not started
MySQL thread id 922771373, OS thread handle 0x7fe829fff700, query id 48666146 10.27.229.248 rduser cleaning up
---TRANSACTION 422110527055976, not started
MySQL thread id 1359413486, OS thread handle 0x7fe8447ff700, query id 48671159 10.27.229.248 rduser cleaning up
---TRANSACTION 422110741172328, not started
MySQL thread id 1343037747, OS thread handle 0x7fe8052fb700, query id 48671150 10.27.229.248 rduser cleaning up
---TRANSACTION 422110120196200, not started
MySQL thread id 1074387321, OS thread handle 0x7fe82c7be700, query id 48636065 10.27.229.248 rduser cleaning up
---TRANSACTION 422109801637992, not started
MySQL thread id 1342794705, OS thread handle 0x7fe81373c700, query id 48671138 10.27.229.248 rduser cleaning up
---TRANSACTION 422110472304744, not started
MySQL thread id 1359121638, OS thread handle 0x7fe8413ff700, query id 48671145 10.27.229.248 rduser cleaning up
---TRANSACTION 422111089649768, not started
MySQL thread id 1074394768, OS thread handle 0x7fe80bbff700, query id 48671124 10.27.229.248 rduser cleaning up
---TRANSACTION 422110199687272, not started
MySQL thread id 1074237357, OS thread handle 0x7fe8313be700, query id 48671132 10.27.229.248 rduser cleaning up
---TRANSACTION 422110426191976, not started
MySQL thread id 1359267942, OS thread handle 0x7fe7ff37d700, query id 48667627 10.27.229.248 rduser cleaning up
---TRANSACTION 422110178721896, not started
MySQL thread id 923055675, OS thread handle 0x7fe7fbb7d700, query id 48667604 10.27.229.248 rduser cleaning up
---TRANSACTION 422110325723240, not started
MySQL thread id 1073931566, OS thread handle 0x7fe7fd33c700, query id 42665122 202.108.36.107 opt cleaning up
---TRANSACTION 422111005763688, not started
MySQL thread id 1359874828, OS thread handle 0x7fe8117ff700, query id 42650112 202.108.36.107 opt cleaning up
---TRANSACTION 422110535897192, not started
MySQL thread id 1342679201, OS thread handle 0x7fe800bbe700, query id 42649007 202.108.36.107 opt cleaning up
---TRANSACTION 422110044489832, not started
MySQL thread id 1041103075, OS thread handle 0x7fe827bff700, query id 46069378 202.108.36.107 opt cleaning up
---TRANSACTION 422111014146152, not started
MySQL thread id 923328772, OS thread handle 0x7fe810bbe700, query id 48534487 202.108.36.107 opt cleaning up
---TRANSACTION 422111114653800, not started
MySQL thread id 1342254843, OS thread handle 0x7fe80baba700, query id 48669959 10.24.19.222 rduser cleaning up
---TRANSACTION 422110472853608, not started
MySQL thread id 1057213278, OS thread handle 0x7fe7ffe79700, query id 48671157 10.24.19.222 rduser cleaning up
---TRANSACTION 422110229049448, not started
MySQL thread id 923119541, OS thread handle 0x7fe7fc7be700, query id 48671153 10.24.19.222 rduser cleaning up
---TRANSACTION 422109914900584, not started
MySQL thread id 1342933069, OS thread handle 0x7fe816fff700, query id 48669984 10.24.19.222 rduser cleaning up
---TRANSACTION 422110124202088, not started
MySQL thread id 1343035055, OS thread handle 0x7fe7fbaba700, query id 48671147 10.24.19.222 rduser cleaning up
---TRANSACTION 422109776443496, not started
MySQL thread id 1343042281, OS thread handle 0x7fe823bff700, query id 48633588 10.24.19.222 rduser cleaning up
---TRANSACTION 422110753763432, not started
MySQL thread id 1040839875, OS thread handle 0x7fe80533c700, query id 48671141 10.24.19.222 rduser cleaning up
---TRANSACTION 422110281324648, not started
MySQL thread id 1040841238, OS thread handle 0x7fe7fd1f7700, query id 48669992 10.24.19.222 rduser cleaning up
---TRANSACTION 422110141163624, not started
MySQL thread id 923600080, OS thread handle 0x7fe82d7ff700, query id 41605576 202.108.36.107 opt cleaning up
---TRANSACTION 422110203979880, not started
MySQL thread id 1041179806, OS thread handle 0x7fe7fc77d700, query id 41564050 202.108.36.107 opt cleaning up
---TRANSACTION 422110011136104, not started
MySQL thread id 1057827072, OS thread handle 0x7fe8263be700, query id 41599323 202.108.36.107 opt cleaning up
---TRANSACTION 422109860167784, not started
MySQL thread id 1041061029, OS thread handle 0x7fe81cbff700, query id 43446451 202.108.36.107 opt cleaning up
---TRANSACTION 422110484889704, not started
MySQL thread id 1057464722, OS thread handle 0x7fe7ffeba700, query id 48402681 202.108.36.107 opt cleaning up
---TRANSACTION 422110124181608, not started
MySQL thread id 1057238155, OS thread handle 0x7fe82c7ff700, query id 41923732 202.108.36.107 opt cleaning up
---TRANSACTION 422110283790440, not started
MySQL thread id 923643585, OS thread handle 0x7fe7fd238700, query id 41273264 10.24.19.222 rduser cleaning up
---TRANSACTION 422111131371624, not started
MySQL thread id 1073814876, OS thread handle 0x7fe80b9f7700, query id 48621268 10.24.19.222 rduser cleaning up
---TRANSACTION 422111106183272, not started
MySQL thread id 1040764184, OS thread handle 0x7fe80bafb700, query id 40761318 202.108.36.107 opt cleaning up
---TRANSACTION 422110544169064, not started
MySQL thread id 922840501, OS thread handle 0x7fe8016fb700, query id 40647663 202.108.36.107 opt cleaning up
---TRANSACTION 422110761850984, not started
MySQL thread id 1041087021, OS thread handle 0x7fe80ba79700, query id 42571320 202.108.36.107 opt cleaning up
---TRANSACTION 422110787926120, not started
MySQL thread id 1040480783, OS thread handle 0x7febfec06700, query id 40440027 202.108.36.107 opt cleaning up
---TRANSACTION 422111151394920, not started
MySQL thread id 1359347070, OS thread handle 0x7fe80b975700, query id 40439045 202.108.36.107 opt cleaning up
---TRANSACTION 422111151368296, not started
MySQL thread id 923567612, OS thread handle 0x7fe8541e3700, query id 42506390 202.108.36.107 opt cleaning up
---TRANSACTION 422110625859688, not started
MySQL thread id 1359855143, OS thread handle 0x7fe802fbe700, query id 40200645 202.108.36.107 opt cleaning up
---TRANSACTION 422110233481320, not started
MySQL thread id 1040880568, OS thread handle 0x7fe7fc7ff700, query id 48670282 10.24.19.222 rduser cleaning up
---TRANSACTION 422109751179368, not started
MySQL thread id 923216982, OS thread handle 0x7fe8187ff700, query id 40565427 202.108.36.107 opt cleaning up
---TRANSACTION 422110032287848, not started
MySQL thread id 1074779416, OS thread handle 0x7fe826fff700, query id 17616103 202.108.36.107 opt cleaning up
---TRANSACTION 422109746897000, not started
MySQL thread id 1057674240, OS thread handle 0x7fe8163be700, query id 17525300 202.108.36.107 opt cleaning up
---TRANSACTION 422109868537960, not started
MySQL thread id 1057480211, OS thread handle 0x7fe81d7be700, query id 40522143 10.24.19.222 rduser cleaning up
---TRANSACTION 422110992496744, not started
MySQL thread id 1074451046, OS thread handle 0x7fe8127ff700, query id 17111575 202.108.36.107 opt cleaning up
---TRANSACTION 422109721530472, not started
MySQL thread id 1040955800, OS thread handle 0x7fe8147ff700, query id 16825786 202.108.36.107 opt cleaning up
---TRANSACTION 422110510094440, not started
MySQL thread id 1074687631, OS thread handle 0x7fe843bbe700, query id 17104939 202.108.36.107 opt cleaning up
---TRANSACTION 422110296166504, not started
MySQL thread id 1040673351, OS thread handle 0x7fe81e7ff700, query id 42649002 202.108.36.107 opt cleaning up
---TRANSACTION 422110568788072, not started
MySQL thread id 1041130574, OS thread handle 0x7fe846fff700, query id 18001589 202.108.36.107 opt cleaning up
---TRANSACTION 422109872537704, not started
MySQL thread id 923129509, OS thread handle 0x7fe81d7ff700, query id 41614609 202.108.36.107 opt cleaning up
---TRANSACTION 422110296146024, not started
MySQL thread id 1073945331, OS thread handle 0x7fe836bff700, query id 13430902 202.108.36.107 opt cleaning up
---TRANSACTION 422110426181736, not started
MySQL thread id 923139681, OS thread handle 0x7fe83e7ff700, query id 42650030 202.108.36.107 opt cleaning up
--------
FILE I/O
--------
I/O thread 0 state: waiting for i/o request (insert buffer thread)
I/O thread 1 state: waiting for i/o request (log thread)
I/O thread 2 state: waiting for i/o request (read thread)
I/O thread 3 state: waiting for i/o request (read thread)
I/O thread 4 state: waiting for i/o request (read thread)
I/O thread 5 state: waiting for i/o request (read thread)
I/O thread 6 state: waiting for i/o request (write thread)
I/O thread 7 state: waiting for i/o request (write thread)
I/O thread 8 state: waiting for i/o request (write thread)
I/O thread 9 state: waiting for i/o request (write thread)
Pending normal aio reads: 0 [0, 0, 0, 0] , aio writes: 0 [0, 0, 0, 0] ,
 ibuf aio reads: 0, log i/o's: 0, sync i/o's: 0
Pending flushes (fsync) log: 0; buffer pool: 0
16357557 OS file reads, 21677701 OS file writes, 12649747 OS fsyncs
0.00 reads/s, 0 avg bytes/read, 171.53 writes/s, 148.59 fsyncs/s
-------------------------------------
INSERT BUFFER AND ADAPTIVE HASH INDEX
-------------------------------------
Ibuf: size 1, free list len 152295, seg size 152297, 509490 merges
merged operations:
 insert 36501, delete mark 74464807, delete 1221
discarded operations:
 insert 0, delete mark 0, delete 0
AHI PARTITION 1: Hash table size 3187567, node heap has 2611 buffer(s)
AHI PARTITION 2: Hash table size 3187567, node heap has 205 buffer(s)
AHI PARTITION 3: Hash table size 3187567, node heap has 278 buffer(s)
AHI PARTITION 4: Hash table size 3187567, node heap has 1204 buffer(s)
AHI PARTITION 5: Hash table size 3187567, node heap has 289 buffer(s)
AHI PARTITION 6: Hash table size 3187567, node heap has 773 buffer(s)
AHI PARTITION 7: Hash table size 3187567, node heap has 315 buffer(s)
AHI PARTITION 8: Hash table size 3187567, node heap has 341 buffer(s)
5186.43 hash searches/s, 821.57 non-hash searches/s
---
LOG
---
Log sequence number 887951919628
Log flushed up to   887951919509
Pages flushed up to 887951726865
Last checkpoint at  887951405984
0 pending log flushes, 0 pending chkp writes
8747621 log i/o's done, 118.00 log i/o's/second
----------------------
BUFFER POOL AND MEMORY
----------------------
Total memory allocated 13218349056; in additional pool allocated 0
Dictionary memory allocated 2165186
Buffer pool size   786432
Free buffers       8196
Database pages     772220
Old database pages 284896
Modified db pages  358
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 1820256, not young 414801496
0.03 youngs/s, 0.00 non-youngs/s
Pages read 25072109, created 826468, written 26804554
0.00 reads/s, 0.12 creates/s, 100.53 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 772220, unzip_LRU len: 0
I/O sum[38752]:cur[0], unzip sum[0]:cur[0]
----------------------
INDIVIDUAL BUFFER POOL INFO
----------------------
---BUFFER POOL 0
Buffer pool size   98304
Free buffers       1024
Database pages     96530
Old database pages 35613
Modified db pages  167
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 245538, not young 51119567
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3117169, created 102779, written 4977022
0.00 reads/s, 0.00 creates/s, 42.00 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96530, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 1
Buffer pool size   98304
Free buffers       1024
Database pages     96495
Old database pages 35600
Modified db pages  11
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 198595, not young 50847534
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3135209, created 106320, written 2489087
0.00 reads/s, 0.03 creates/s, 4.44 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96495, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 2
Buffer pool size   98304
Free buffers       1025
Database pages     96544
Old database pages 35618
Modified db pages  20
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 245553, not young 52036985
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3144631, created 102585, written 2462822
0.00 reads/s, 0.00 creates/s, 5.87 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96544, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 3
Buffer pool size   98304
Free buffers       1024
Database pages     96538
Old database pages 35616
Modified db pages  67
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 242397, not young 52509152
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3143878, created 100804, written 4016563
0.00 reads/s, 0.00 creates/s, 19.41 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96538, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 4
Buffer pool size   98304
Free buffers       1024
Database pages     96520
Old database pages 35609
Modified db pages  51
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 198239, not young 51515999
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3165054, created 104304, written 4032756
0.00 reads/s, 0.03 creates/s, 14.12 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96520, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 5
Buffer pool size   98304
Free buffers       1026
Database pages     96527
Old database pages 35612
Modified db pages  19
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 246192, not young 52160044
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3133484, created 103588, written 2833905
0.00 reads/s, 0.00 creates/s, 4.72 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96527, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 6
Buffer pool size   98304
Free buffers       1025
Database pages     96527
Old database pages 35612
Modified db pages  12
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 242006, not young 54466493
0.00 youngs/s, 0.00 non-youngs/s
Pages read 3109764, created 102378, written 3377940
0.00 reads/s, 0.00 creates/s, 4.25 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96527, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
---BUFFER POOL 7
Buffer pool size   98304
Free buffers       1024
Database pages     96539
Old database pages 35616
Modified db pages  11
Pending reads 0
Pending writes: LRU 0, flush list 0, single page 0
Pages made young 201736, not young 50145722
0.03 youngs/s, 0.00 non-youngs/s
Pages read 3122920, created 103710, written 2614459
0.00 reads/s, 0.06 creates/s, 5.72 writes/s
Buffer pool hit rate 1000 / 1000, young-making rate 0 / 1000 not 0 / 1000
Pages read ahead 0.00/s, evicted without access 0.00/s, Random read ahead 0.00/s
LRU len: 96539, unzip_LRU len: 0
I/O sum[4844]:cur[0], unzip sum[0]:cur[0]
--------------
ROW OPERATIONS
--------------
0 queries inside InnoDB, 0 queries in queue
25 read views open inside InnoDB
Main thread process no. 14944, id 140635908585216, state: sleeping
Number of rows inserted 2525942, updated 9901482, deleted 61977724, read 222192991731
3.16 inserts/s, 108.72 updates/s, 0.50 deletes/s, 1500527.23 reads/s
----------------------------
END OF INNODB MONITOR OUTPUT
============================
