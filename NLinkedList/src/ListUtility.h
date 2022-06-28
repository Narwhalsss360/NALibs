#ifndef ListUtility_h
#define ListUtility_h

#include "declNLinkedList.h"

#define NEW_LISTUTILITY(n, T) typedef ListUtility<T> n

template <typename T>
class ListUtility
{
public:
	ListUtility();
	void reverse(LinkedList<T>*);
	void bubbleSort(LinkedList<T>*, int (*)(T*, T*));
	~ListUtility();
};

#endif