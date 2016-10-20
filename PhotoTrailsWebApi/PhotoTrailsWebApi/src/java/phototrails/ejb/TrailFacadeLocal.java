/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package phototrails.ejb;

import java.util.List;
import javax.ejb.Local;
import phototrails.entity.Trail;

/**
 *
 * @author ealesec
 */
@Local
public interface TrailFacadeLocal {

    void create(Trail trail);

    void edit(Trail trail);

    void remove(Trail trail);

    Trail find(Object id);

    List<Trail> findAll();

    List<Trail> findRange(int[] range);

    int count();
    
}
