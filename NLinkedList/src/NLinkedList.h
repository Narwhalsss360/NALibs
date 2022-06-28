#ifndef _NLinkedList_h
#define _NLinkedList_h

#include "declNLinkedList.h"
#include "EasyNode.h"
#include "ListUtility.h"

#pragma region Macros
#define claimed(i) (i->owner != nullptr)
#define owned(i) (i->owner == this)
#define NBC(it) ((Node<T>*)it)
#define NEW_EASYLIST(n, T) typedef LinkedList<T> n
#define foreach_node(t, l) for (t : l)

#ifndef __EXCLUDE_FOREACH__
#define foreach(namedtype, arracc, size, def) for (uint32_t __iterator__ = 0; __iterator__ < size; __iterator__++) { namedtype = arracc[__iterator__]; def }
#endif
#pragma endregion

#pragma region Node<typename> Defenition
template <typename T>
Node<T>::Node()
	: owner(nullptr), index(0), previousNode(nullptr), nextNode(nullptr)
{
}

template <typename T>
NodeIndex Node<T>::getNodeIndex()
{
	return index;
}

template <typename T>
Node<T>* Node<T>::getPreviousNode()
{
	return previousNode;
}

template <typename T>
Node<T>* Node<T>::getNextNode()
{
	return nextNode;
}

template <typename T>
Node<T>::~Node()
{
	if (owner) owner->remove(this);
}
#pragma endregion

#pragma region INode
template<typename T>
INode<T>::INode(Node<T>* newItem)
	: current(newItem)
{
}

template <typename T>
bool INode<T>::operator!=(INode<T> r)
{
	return (current != nullptr);
}

template <typename T>
T& INode<T>::operator*()
{
	return *(T*)current;
}

template <typename T>
void INode<T>::operator++()
{
	current = current->nextNode;
}

template <typename T>
INode<T>::~INode()
{
}
#pragma endregion

#pragma region LinkedList<typename> Defenition
template <typename T>
LinkedList<T>::LinkedList()
	: count(0), head(nullptr), tail(nullptr)
{
}

template <typename T>
void LinkedList<T>::append(T* Titem)
{
	Node<T>* item = NBC(Titem);

	if (claimed(item)) return;

	if (count)
	{
		tail->nextNode = item;
		item->previousNode = tail;
	}
	else
	{
		head = item;
		item->previousNode = nullptr;
	}

	item->nextNode = nullptr;
	item->owner = this;
	item->index = count;
	count++;
	tail = item;
}

template <typename T>
void LinkedList<T>::prepend(T* Titem)
{
	Node<T>* item = NBC(Titem);
	if (claimed(item)) return;

	if (count)
	{
		head->previousNode = item;
		item->nextNode = head;
		head = item;
	}
	else
	{
		head = item;
		item->nextNode = nullptr;
		tail = item;
	}

	item->previousNode = nullptr;
	item->owner = this;
	item->index = 0;
	incrementIndices(item);
	count++;
}

template <typename T>
void LinkedList<T>::insert(T* Titem, NodeIndex index)
{
	Node<T>* item = NBC(Titem);
	if (claimed(item)) return;

	Node<T>* itemAtIndex = get(index);

	item->nextNode = itemAtIndex->nextNode;
	itemAtIndex->nextNode = item;

	item->previousNode = itemAtIndex;
	item->nextNode->previousNode = item;

	item->owner = this;
	item->index = itemAtIndex->index + 1;
	incrementIndices(item);
	count++;
}

template <typename T>
void LinkedList<T>::remove(T* Titem)
{
	Node<T>* item = NBC(Titem);
	if (!owned(item)) return;

	if (item == head)
	{
		head = item->nextNode;
		decrementIndices(item);

		item->previousNode = nullptr;
		item->nextNode = nullptr;
		item->index = 0;
		item->owner = nullptr;
		count--;
		return;
	}
	else if (item == tail)
	{
		tail = item->previousNode;

		item->previousNode = nullptr;
		item->nextNode = nullptr;
		item->index = 0;
		item->owner = nullptr;
		count--;
		return;
	}

	item->previousNode->nextNode = item->nextNode;
	item->nextNode->previousNode = item->previousNode;
	decrementIndices(item);

	item->previousNode = nullptr;
	item->nextNode = nullptr;
	item->index = 0;
	item->owner = nullptr;
	count--;
}

template <typename T>
void LinkedList<T>::swap(T* TitemA, T* TitemB)
{
	Node<T>* itemA = NBC(TitemA);
	Node<T>* itemB = NBC(TitemB);

	if (!owned(itemA)) return;
	if (!owned(itemB)) return;

	if (itemA == head) head = itemB;
	else if (itemB == head) head = itemA;

	if (itemA == tail) tail = itemB;
	else if (itemB == tail) tail = itemA;

	NodeIndex itemAIndex = itemA->index;
	itemA->index = itemB->index;
	itemB->index = itemAIndex;

	Node<T>* itemANext = itemA->nextNode;
	itemA->nextNode = itemB->nextNode;
	if (itemA->nextNode) itemA->nextNode->previousNode = itemA;

	itemB->nextNode = itemANext;
	if (itemB->nextNode) itemB->nextNode->previousNode = itemB;

	Node<T>* itemAPrevious = itemA->previousNode;
	itemA->previousNode = itemB->previousNode;
	if (itemA->previousNode) itemA->previousNode->nextNode = itemA;

	itemB->previousNode = itemAPrevious;
	if (itemB->previousNode) itemB->previousNode->nextNode = itemB;
}

template <typename T>
NodeIndex LinkedList<T>::length()
{
	return count;
}

template <typename T>
Node<T>* LinkedList<T>::get(NodeIndex index)
{
	if (index >= count) return;

	Node<T>* current = head;
	while (current)
	{
		if (current->index == index) return current;
		current = current->nextNode;
	}
	return nullptr;
}

template <typename T>
void LinkedList<T>::incrementIndices(Node<T>* start)
{
	Node<T>* current = start->nextNode;
	while (current)
	{
		current->index++;
		current = current->nextNode;
	}
}

template <typename T>
void LinkedList<T>::decrementIndices(Node<T>* start)
{
	Node<T>* current = start->nextNode;
	while (current)
	{
		current->index--;
		current = current->nextNode;
	}
}

template <typename T>
T& LinkedList<T>::operator[](NodeIndex index)
{
	return *((T*)get(index));
}

template <typename T>
void LinkedList<T>::operator+=(T& item)
{
	append(&item);
}

template <typename T>
void LinkedList<T>::operator-=(T& item)
{
	remove(&item);
}

template <typename T>
INode<T> LinkedList<T>::begin()
{
	if (!count) return;
	return INode<T>(head);
}

template <typename T>
INode<T> LinkedList<T>::end()
{
	return INode<T>(tail);
}

template <typename T>
LinkedList<T>::~LinkedList()
{
}
#pragma endregion

#pragma region EasyNode
template <typename T>
EasyNode<T>::EasyNode()
{
}

template <typename T>
EasyNode<T>::EasyNode(T& _data_)
	: data(_data_)
{
}

template <typename T>
EasyNode<T>::EasyNode(T&& _data_)
	: data(_data_)
{
}

template <typename T>
T& EasyNode<T>::get() const
{
	return data;
}

template <typename T>
void EasyNode<T>::set(T& _data_)
{
	data = _data_;
}

template <typename T>
void EasyNode<T>::set(T&& _data_)
{
	data = _data_;
}

template <typename T>
EasyNode<T>::operator T& () const
{
	return get();
}

template <typename T>
void EasyNode<T>::operator=(T& _data_)
{
	set(_data_);
}

template <typename T>
void EasyNode<T>::operator=(T&& _data_)
{
	set(_data_);
}
#pragma endregion

#pragma region ListUtility
template <typename T>
ListUtility<T>::ListUtility()
{
}

template <typename T>
void ListUtility<T>::reverse(LinkedList<T>* list)
{
	Node<T>* current = list->head;
	list->tail = current;

	while (true)
	{
		Node<T>* tempNext = current->nextNode;
		current->nextNode = current->previousNode;
		current->previousNode = tempNext;

		current->index = ((-1 * current->index) + (list->count - 1));

		if (tempNext == nullptr)
		{
			list->head = current;
			return;
		}
		current = tempNext;
	}
}

template <typename T>
void ListUtility<T>::bubbleSort(LinkedList<T>* list, int (*compareFunction)(T*, T*))
{
	for (NodeIndex Outer = 0; Outer < list->length() - 1; Outer++)
	{
		for (NodeIndex Inner = 0; Inner < list->length() - Outer - 1; Inner++)
		{
			T* itemA = &(*list)[Inner];
			T* itemB = &(*list)[Inner + 1];
			if (compareFunction(itemA, itemB) > 0) list->swap(itemA, itemB);
		}
	}
}
template <typename T>
ListUtility<T>::~ListUtility()
{
}
#pragma endregion

#pragma region Undefs
#undef claimed
#undef owned
#undef NBC
#pragma endregion

#endif