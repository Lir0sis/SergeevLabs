#include <chrono>
#include <functional>
#include <cstdlib>

#include <graph.h>

auto elapsed(std::function<void()> foo) {
  using clock = std::chrono::high_resolution_clock;

  auto start = clock::now();
  foo();
  auto end = clock::now();

  return std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
}

int main(int argc, char **argv) {
  ds::directed_graph<int> graph;
  std::unordered_set<int> values;

  std::size_t size = std::atoi(argv[1]);
  std::srand(std::time(0));

  auto gen_time = elapsed(
    [&graph, &values, &size] () {
      for(int i = 0; i < size; i++) {
        int value = rand() % size;
        graph.add_vertex(value);
        values.insert(value);
      }

      for(int i = 0; i < size; i++) {
        for(int j = 0; j < size; j++) {
          if(std::rand() % 2 == 0) graph.add_edge(i, j);
        }
      }
    }
  );

  auto search_time = elapsed(
    [&graph, &values] () {
      graph.search(*values.begin());
    }
  );

  std::cout << "searching: " << search_time << "µs\n";
}
