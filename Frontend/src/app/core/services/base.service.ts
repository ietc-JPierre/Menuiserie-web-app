import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<T>
{
  protected http = inject(HttpClient);

  items = signal<T[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);
}