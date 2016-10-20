/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package phototrails.ejb;

import java.util.List;
import javax.ejb.Local;
import phototrails.entity.Trackpoint;

/**
 *
 * @author ealesec
 */
@Local
public interface TrackpointFacadeLocal {

    void create(Trackpoint trackpoint);

    void edit(Trackpoint trackpoint);

    void remove(Trackpoint trackpoint);

    Trackpoint find(Object id);

    List<Trackpoint> findAll();

    List<Trackpoint> findRange(int[] range);

    int count();
    
}
