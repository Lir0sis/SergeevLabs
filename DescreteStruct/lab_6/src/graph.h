#include <vector>
#include <list>
#include <stack>
#include <queue>
#include <unordered_set>
#include <iostream>


namespace ds {
  template <typename _T>
  class directed_graph {
    using index = std::size_t;
    using list = std::list<index>;

    struct vertex {
      vertex(const _T &value) : value(value) {}
      _T value;
      list edges;
    };

    using array = std::vector<vertex>;

    using set = std::unordered_set<index>;
    using stack = std::stack<index>;
    using queue = std::queue<index>;
  public:
    directed_graph() = default;
    directed_graph(const directed_graph &) = default;
    directed_graph(directed_graph &&) = default;
    ~directed_graph() = default;

    void add_vertex(const _T &value) {
      m_vertices.emplace_back(value);
    }
    void add_edge(const index& from, const index& to) {
      m_vertices.at(from).edges.push_back(to);
    }
    index size() {
      return m_vertices.size();
    }

    #if defined(BFS)
    index search(const _T &value, const index root = 0) {
      index occurances = 0;
      set visited;
      queue queue;

      queue.push(root);
      visited.insert(root);

      while(!queue.empty()) {
        index vertex = queue.front();
        queue.pop();

        if(m_vertices[vertex].value == value) occurances++;

        for(auto &neighbour : m_vertices[vertex].edges) {
          if(visited.find(neighbour) == visited.end()) {
            queue.push(neighbour);
            visited.insert(neighbour);
          }
        }
      }

      return occurances;
    }
    #elif defined(DFS)
    index search(const _T &value, const index root = 0) {
      index occurances = 0;
      set visited;
      stack stack;

      stack.push(root);
      visited.insert(root);

      while(!stack.empty()) {
        index vertex = stack.top();
        stack.pop();

        if(m_vertices[vertex].value == value) occurances++;

        for(auto &neighbour : m_vertices[vertex].edges) {
          if(visited.find(neighbour) == visited.end()) {
            stack.push(neighbour);
            visited.insert(neighbour);
          }
        }
      }

      return occurances;
    }
    #endif

    friend std::ostream& operator<<(std::ostream& os, const directed_graph<_T> &obj) {
      for(int i = 0; i < obj.m_vertices.size(); i++) {
        auto &vertex = obj.m_vertices[i];

        os << i << ": {" << vertex.value << "} -> ";

        for (auto &index : vertex.edges) {
          os << index << ", ";
        }
        os << "\n";
      }
      return os;
    }
  private:
    array m_vertices;
  };

  // template <typename _T>
  // std::ostream& operator<<(std::ostream& os, const directed_graph<_T> &obj)
}
