cmake_minimum_required(VERSION 3.11)

project("lab2" VERSION 1.0 LANGUAGES C CXX)

# set(CMAKE_BUILD_TYPE Debug)

#------------------------------------------------------
add_executable(
  profile_dfs
  src/profile.cpp
)

target_compile_definitions(profile_dfs PRIVATE DFS)

target_compile_features(profile_dfs PRIVATE cxx_std_17)
#------------------------------------------------------

#------------------------------------------------------
add_executable(
  profile_bfs
  src/profile.cpp
)

target_compile_definitions(profile_bfs PRIVATE BFS)

target_compile_features(profile_bfs PRIVATE cxx_std_17)
#------------------------------------------------------


include_directories(
  "src/"
)
