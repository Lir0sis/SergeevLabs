from subprocess import Popen, PIPE
from re import search

step = 100
runs_per_step = 5
runs_total = 20

targets = ["build/profile_bfs",
           "build/profile_dfs"]


for _target in targets:
    print("searching, ", end="")

    for _run in range(1, runs_total+ 1):
        search_avg = 0

        for _ in range(runs_per_step):
            process = Popen([_target, str(_run * step)], stdout=PIPE, stderr=PIPE)
            stdout = (process.communicate()[0]).decode()

            search_str = search(r"searching: ([0-9]{0,})µs", stdout).group(1)
            search_avg = (search_avg + int(search_str)) / 2

        print(f"{search_avg}, ", end="")

    print("")
